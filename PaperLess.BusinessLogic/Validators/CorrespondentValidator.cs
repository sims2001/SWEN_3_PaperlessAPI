using FluentValidation;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Validators {

    public class CorrespondentValidator : AbstractValidator<Correspondent> {
        public CorrespondentValidator() {
            RuleFor(correspondent => correspondent.Slug).NotEmpty().WithMessage("Slug is required");
            RuleFor(correspondent => correspondent.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(correspondent => correspondent.Match).NotEmpty().WithMessage("Match is required");
            RuleFor(correspondent => correspondent.MatchingAlgorithm).GreaterThan(0).WithMessage("MatchingAlgorithm must be greater than 0");
            RuleFor(correspondent => correspondent.DocumentCount).GreaterThanOrEqualTo(0).WithMessage("DocumentCount must be greater than or equal to 0");
            RuleFor(correspondent => correspondent.LastCorrespondence).NotEmpty().WithMessage("LastCorrespondence is required");
        }
    }
}