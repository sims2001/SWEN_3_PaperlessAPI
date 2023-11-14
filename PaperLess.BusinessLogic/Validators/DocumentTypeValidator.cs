using FluentValidation;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Validators {
    public class DocumentTypeValidator : AbstractValidator<DocumentType> {
        public DocumentTypeValidator() {
            RuleFor(documentType => documentType.Slug).NotEmpty().WithMessage("Slug is required");
            RuleFor(documentType => documentType.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(documentType => documentType.Match).NotEmpty().WithMessage("Match is required");
            RuleFor(documentType => documentType.MatchingAlgorithm).GreaterThan(0).WithMessage("MatchingAlgorithm must be greater than 0");
            RuleFor(documentType => documentType.DocumentCount).GreaterThanOrEqualTo(0).WithMessage("DocumentCount must be greater than or equal to 0");
        }
    }
}