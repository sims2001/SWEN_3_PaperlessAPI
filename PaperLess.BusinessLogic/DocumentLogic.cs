using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using System.Xml.Linq;
using FluentValidation;
using PaperLess.BusinessLogic.Validation;
using Microsoft.Extensions.Logging;
using PaperLess.DataAccess.Interfaces;

namespace PaperLess.BusinessLogic {

    public class DocumentLogic : IDocumentLogic {
        private readonly IValidator<Document> _validator;
        private readonly IDocumentRepository _repository;
        private readonly ILogger<DocumentLogic> _logger;

        public DocumentLogic(IValidator<Document> validator, IDocumentRepository repository, ILogger<DocumentLogic> logger) {
            _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        public List<Document> GetDocuments(int? page, int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId,
            int? storagePathIdIn, int? correspondentId, bool? truncateContent) {
            throw new NotImplementedException();
        }

        public BusinessLogicResult CreateDocument(Document document) {

            var validationResult = _validator.Validate(document);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            _repository.AddDocument(document);

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
    }

}