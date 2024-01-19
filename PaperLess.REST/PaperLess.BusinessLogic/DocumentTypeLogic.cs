using FluentValidation;
using Microsoft.Extensions.Logging;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.BusinessLogic.Validation;

namespace PaperLess.BusinessLogic {

    public class DocumentTypeLogic : IDocumentTypeLogic {

        private readonly IValidator<DocumentType> _validator;

        private readonly ILogger<DocumentTypeLogic> _logger;
        public DocumentTypeLogic(IValidator<DocumentType> validator, ILogger<DocumentTypeLogic> logger) {
            _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        public List<DocumentType> GetDocumentTypes(int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public BusinessLogicResult<DocumentType> CreateDocumentType(DocumentType documentType) {
            var validationResult = _validator.Validate(documentType);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<DocumentType> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            documentType.Name= "funnyfink";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<DocumentType> {
                IsSuccess = true,
                Result = documentType
            };
        }

        public BusinessLogicResult<DocumentType> UpdateDocumentType(int id, DocumentType documentType) {
            var validationResult = _validator.Validate(documentType);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<DocumentType> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            documentType.Name = "funnyfink";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<DocumentType> {
                IsSuccess = true,
                Result = documentType
            };
        }

        public BusinessLogicResult DeleteDocumentType(int id) {
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