using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using System.Xml.Linq;
using FluentValidation;
using PaperLess.BusinessLogic.Validation;
using Microsoft.Extensions.Logging;
using PaperLess.DataAccess.Interfaces;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PaperLess.Queue.Interfaces;

namespace PaperLess.BusinessLogic {

    public class DocumentLogic : IDocumentLogic {
        private readonly IValidator<Document> _validator;
        private readonly IDocumentRepository _repository;
        private readonly ILogger<DocumentLogic> _logger;
        private readonly IMinioClient _minioClient;
        private readonly IQueueProducer _publisher;

        public DocumentLogic(IValidator<Document> validator, IDocumentRepository repository, ILogger<DocumentLogic> logger, IMinioClient minioClient, IQueueProducer publisher) {
            _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
            _minioClient = minioClient ?? throw new ArgumentNullException(nameof(_minioClient));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(_publisher));
        }
        public List<Document> GetDocuments(int? page, int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId,
            int? storagePathIdIn, int? correspondentId, bool? truncateContent) {
            throw new NotImplementedException();
        }


        //public async Task<BusinessLogicResult> CreateDocument(Document document)
        public async Task<BusinessLogicResult> CreateDocument(Document document) {

            _logger.LogInformation($"Validating Document: {document}");
            var validationResult = _validator.Validate(document);

            if (!validationResult.IsValid) {
                _logger.LogWarning($"Document Validation Failed!");
                return new BusinessLogicResult {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            try
            {
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

                var message = JsonConvert.SerializeObject(messageContent);
                //Step 3c
                _publisher.PublishToQueue(message);
                _logger.LogInformation($"Published Message to Queue: {message}");

                return new BusinessLogicResult
                {
                    IsSuccess = true,
                };
            } catch(Exception e ) 
            {
                _logger.LogWarning($"Could not create document");
                return new BusinessLogicResult
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
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

            try {

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
            } catch (MinioException e)
            {
                _logger.LogError("Couldnt save File to MinIO");
            }

            return uniqueName;
        }
    }

}