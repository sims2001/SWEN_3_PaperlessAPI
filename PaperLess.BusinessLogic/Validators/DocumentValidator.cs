using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Validators {
    public class DocumentValidator : AbstractValidator<Document> {
        public DocumentValidator() {
            RuleFor(document => document.Correspondent).NotNull().WithMessage("Correspondent is required");
            RuleFor(document => document.DocumentType).NotNull().WithMessage("DocumentType is required");
            RuleFor(document => document.StoragePath).NotNull().WithMessage("StoragePath is required");
            RuleFor(document => document.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(document => document.Content).NotEmpty().WithMessage("Content is required");
            RuleFor(document => document.Tags).NotNull().WithMessage("Tags is required");
            RuleFor(document => document.Created).NotEmpty().WithMessage("Created is required");
            RuleFor(document => document.CreatedDate).NotEmpty().WithMessage("CreatedDate is required");
            RuleFor(document => document.Modified).NotEmpty().WithMessage("Modified is required");
            RuleFor(document => document.Added).NotEmpty().WithMessage("Added is required");
            RuleFor(document => document.ArchiveSerialNumber).NotEmpty().WithMessage("ArchiveSerialNumber is required");
            RuleFor(document => document.OriginalFileName).NotEmpty().WithMessage("OriginalFileName is required");
            RuleFor(document => document.ArchivedFileName).NotEmpty().WithMessage("ArchivedFileName is required");
        }
    }
}
