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
            try
            {
                correspondent.Name = "funnyfink";
                //TODO: IMPLEMENT DB CALL
                return new BusinessLogicResult<Correspondent>
                {
                    IsSuccess = true,
                    Result = correspondent
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Could not create correspondent");
                return new BusinessLogicResult<Correspondent>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }            
        }

        public BusinessLogicResult<Correspondent> UpdateCorrespondent(int id, Correspondent correspondent) {
            var validationResult = _validator.Validate(correspondent);

            if (!validationResult.IsValid) {
                return new BusinessLogicResult<Correspondent> {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }

            try
            {
                correspondent.Name = "updated";
                //TODO: IMPLEMENT DB CALL
                return new BusinessLogicResult<Correspondent>
                {
                    IsSuccess = true,
                    Result = correspondent
                };
            } catch (Exception e)
            {
                _logger.LogError("Could not update correspondent");
                return new BusinessLogicResult<Correspondent>
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
                };
            }
        }

        public BusinessLogicResult DeleteCorrespondent(int id) {
            if (id <= 0) {
                return new BusinessLogicResult() {
                    IsSuccess = false,
                    Errors = new List<string> { "Invalid ID" }
                };
            }

            try
            {
                //TODO: IMPLEMENT DB CALL
                return new BusinessLogicResult()
                {
                    IsSuccess = true
                };
            } catch (Exception e)
            {
                _logger.LogError("Could not delete correspondent");
                return new BusinessLogicResult()
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Could not Delete Correspondent" }
                };
            }
            
        }
    }
}
