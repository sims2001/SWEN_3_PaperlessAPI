using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Validation {
    public class DocumentValidator : AbstractValidator<Document> {
        public DocumentValidator() {
            RuleFor(document => document.Correspondent).NotNull().WithMessage("Correspondent is required");
            RuleFor(document => document.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(document => document.Content).NotEmpty().WithMessage("Content is required");
            //RuleFor(document => document.Created).NotNull().WithMessage("Created is required");
            //RuleFor(document => document.CreatedDate).NotNull().WithMessage("CreatedDate is required");
            //RuleFor(document => document.Modified).NotNull().WithMessage("Modified is required");
            //RuleFor(document => document.Added).NotNull().WithMessage("Added is required");
        }
    }
}
