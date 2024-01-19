using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;

namespace PaperLess.BusinessLogic {
    public class CorrespondentLogic : ICorrespondentLogic {
        private readonly IValidator<Correspondent> _validator;

        private readonly ILogger<CorrespondentLogic> _logger;
        public CorrespondentLogic(IValidator<Correspondent> validator, ILogger<CorrespondentLogic> logger) {
            _validator = validator ?? throw new ArgumentNullException(nameof(_validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public List<Correspondent> GetCorrespondents(int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public BusinessLogicResult<Correspondent> CreateCorrespondent(Correspondent correspondent) {

            var validationResult = _validator.Validate(correspondent);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Correspondent> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            correspondent.Name = "funnyfink";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<Correspondent> {
                IsSuccess = true,
                Result = correspondent
            };
        }

        public BusinessLogicResult<Correspondent> UpdateCorrespondent(int id, Correspondent correspondent) {
            var validationResult = _validator.Validate(correspondent);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Correspondent> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            correspondent.Name = "updated";
            //TODO: IMPLEMENT DB CALL


            return new BusinessLogicResult<Correspondent> {
                IsSuccess = true,
                Result = correspondent
            };
        }

        public BusinessLogicResult DeleteCorrespondent(int id) {
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
