using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using System.Xml.Linq;
using FluentValidation;
using PaperLess.BusinessLogic.Validation;

namespace PaperLess.BusinessLogic {

    public class DocumentLogic : IDocumentLogic {
        private readonly IValidator<Document> _validator;

        public DocumentLogic(IValidator<Document> validator) {
            _validator = validator;
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

            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult {
                IsSuccess = true,
            };
        }

        public BusinessLogicResult<Document> GetDocument(int id, int? page, bool? fullPerms) {
            throw new NotImplementedException();
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