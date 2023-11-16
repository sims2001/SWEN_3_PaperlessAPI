using FluentValidation;
using FluentValidation.Results;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.BusinessLogic.Validation;
using Microsoft.Extensions.Logging;

namespace PaperLess.BusinessLogic {

    public class TagLogic : ITagLogic {

        private readonly IValidator<Tag> _validator;

        private readonly ILogger<TagLogic> _logger;

        public TagLogic(IValidator<Tag> validator, ILogger<TagLogic> logger) {
            _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }


        public List<Tag> GetTags(int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public BusinessLogicResult<Tag> NewTag(Tag tag) {

            var validationResult = _validator.Validate(tag);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Tag> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            tag.Color = "funnyfink";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<Tag> {
                IsSuccess = true,
                Result = tag
            };

        }

        public BusinessLogicResult<Tag> UpdateTag(int id, Tag tag) {
            ValidationResult validationResult = _validator.Validate(tag);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Tag> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            tag.Color = "updated";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<Tag> {
                IsSuccess = true,
                Result = tag
            };
        }

        public BusinessLogicResult DeleteTag(int id) {
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