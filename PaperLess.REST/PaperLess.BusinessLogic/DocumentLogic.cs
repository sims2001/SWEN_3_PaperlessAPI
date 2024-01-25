using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PaperLess.DataAccess.Interfaces;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PaperLess.BusinessLogic.Interfaces.BlExceptions;
using PaperLess.DataAccess.Interfaces.DalExceptions;
using PaperLess.Queue.Interfaces;
using RabbitMQ.Client.Exceptions;

namespace PaperLess.BusinessLogic {

    public class DocumentLogic : IDocumentLogic {
        private readonly IValidator<Document> _validator;
        private readonly IDocumentRepository _repository;
        private readonly ILogger<DocumentLogic> _logger;
        private readonly IMinioClient _minioClient;
        private readonly IQueueProducer _publisher;

        public DocumentLogic(IValidator<Document> validator, IDocumentRepository repository, ILogger<DocumentLogic> logger, IMinioClient minioClient, IQueueProducer publisher) {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _minioClient = minioClient ?? throw new ArgumentNullException(nameof(minioClient));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }
        public List<Document> GetDocuments(int? page, int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId,
            int? storagePathIdIn, int? correspondentId, bool? truncateContent) {
            throw new NotImplementedException();
        }


        //public async Task<BusinessLogicResult> CreateDocument(Document document)
        public async Task<BusinessLogicResult> CreateDocument(Document document) {
            try {
                
                //Step 3
                _logger.LogInformation($"Validating Document: {document}");
                var validationResult = _validator.Validate(document);

                if (!validationResult.IsValid) {
                    _logger.LogWarning($"Document Validation Failed!");
                    return new BusinessLogicResult {
                        IsSuccess = false,
                        Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                    };
                }

                //STEP 3a
                var documentId = _repository.AddDocument(document);

                //STEP 3b
                var uploadedName = await SaveFile(document.UploadDocument);

                var messageContent = new QueueContent
                {
                    DocumentId = documentId,
                    DocumentTitle = document.Title,
                    UploadedName = uploadedName
                };

                //Step 3c
                var message = JsonConvert.SerializeObject(messageContent);
                _publisher.PublishToQueue(message);
                _logger.LogInformation($"Published Message to Queue: {message}");

                return new BusinessLogicResult
                {
                    IsSuccess = true,
                };
                
            } catch(ValidationException e ) {
                _logger.LogError($"Could not validate document: {e.Message}");
                throw new BlValidationException("Error while Validating Document!", e);
            } catch(DalExceptionBase e ) {
                _logger.LogError($"Could not save document (DAL-Exception): {e.Message}");
                throw new BlDalException("Error while Saving Document in DAL", e);
            } catch(MinioException e ) {
                _logger.LogError($"Could not save document (DAL-Exception): {e.Message}");
                throw new BlMinioException("Error while Storing Document in MinIO!", e);
            } catch(RabbitMQClientException e ) {
                _logger.LogError($"Could not publish message to queue: {e.Message}");
                throw new BlRabbitMqException("Error while Publishing Message to Queue!", e);
            } catch(Exception e ) {
                _logger.LogError($"Error uploading the document: {e.Message}");
                throw new BlExceptionBase("An unknown error occurred in the Business layer", e);
            }
        }

        public BusinessLogicResult<Document> GetDocument(int id, int? page, bool? fullPerms) {
            if (id <= 0)
            {
                return new BusinessLogicResult<Document>()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Invalid ID" }
                };
            }

            try
            {
                var doc = _repository.GetById(id);


                return new BusinessLogicResult<Document>()
                {
                    IsSuccess = true,
                    Result = doc

                };
            } catch (Exception e)
            {
                _logger.LogError("Couldnt get file with ID: " + id +" from DB");
                return new BusinessLogicResult<Document>()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Could not find file with this ID: " + id }
                };
            }
        }

        public BusinessLogicResult<Document> UpdateDocument(int id, Document document) {
            var validationResult = _validator.Validate(document);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Document> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
            try
            {
                document.OriginalFileName = "funnyfink";
                //TODO: IMPLEMENT DB CALL


                return new BusinessLogicResult<Document> {
                    IsSuccess = true,
                    Result = document
                };
            }
            catch(Exception e)
            {
                _logger.LogError("Couldnt update file in DB");
                return new BusinessLogicResult<Document>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
        }

        public BusinessLogicResult DeleteDocument(int id) {
            if (id <= 0) {
                return new BusinessLogicResult() {
                    IsSuccess = false,
                    Errors = new List<string> { "Invalid ID" }
                };
            }

            return new BusinessLogicResult() {
                IsSuccess = true
            };
        }

        protected async Task<string> SaveFile(IFormFile file) {
            _logger.LogInformation($"Saving File '{file.FileName}' to MinIO");

            var bucketName = "paperless-bucket";

            string originalName = file.FileName;
            string UID = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            string uniqueName = $"{UID}_{originalName}";

            var contentType = file.ContentType;

            using (var streamReader = new StreamReader( file.OpenReadStream() )) {
                var memoryStream = new MemoryStream();
                await streamReader.BaseStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var putObjectArgs = new PutObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(uniqueName)
                        .WithStreamData(memoryStream)
                        .WithObjectSize(memoryStream.Length)
                        .WithContentType(contentType);

                await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
                _logger.LogInformation("Saved File to MinIO");
            }

            return uniqueName;
        }
    }

}