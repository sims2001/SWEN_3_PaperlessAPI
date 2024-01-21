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

            var validationResult = _validator.Validate(document);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            //STEP 3a
            var documentId = _repository.AddDocument(document);
            
            //STEP 3b
            var uploadedName = await SaveFile(document.UploadDocument);

            var messageContent = new QueueContent{
                DocumentId = documentId,
                UploadedName = uploadedName
            };

            var message = JsonConvert.SerializeObject(messageContent);
            //Step 3c
            _publisher.PublishToQueue(message);

            return new BusinessLogicResult {
                IsSuccess = true,
            };
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

            var doc = _repository.GetById(id);


            return new BusinessLogicResult<Document>()
            {
                IsSuccess = true,
                Result = doc
                
            };
        }

        public BusinessLogicResult<Document> UpdateDocument(int id, Document document) {
            var validationResult = _validator.Validate(document);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Document> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            document.OriginalFileName = "funnyfink";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<Document> {
                IsSuccess = true,
                Result = document
            };
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

                }
            } catch (MinioException e)
            {
                Console.WriteLine($"Minio Error: {e.Message}");
            }

            return uniqueName;
        }
    }

}