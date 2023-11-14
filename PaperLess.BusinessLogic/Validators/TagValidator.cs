using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Validators {
    public class TagValidator : AbstractValidator<Tag> {
        public TagValidator() {
           // RuleFor(tag => tag.Slug).NotEmpty().WithMessage("Slug is required");
            RuleFor(tag => tag.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(tag => tag.Color).NotEmpty().WithMessage("Color is required");
            RuleFor(tag => tag.Match).NotEmpty().WithMessage("Match is required");
            RuleFor(tag => tag.MatchingAlgorithm).GreaterThanOrEqualTo(0).WithMessage("MatchingAlgorithm must not be lower than 0");
            //RuleFor(tag => tag.DocumentCount).GreaterThanOrEqualTo(0).WithMessage("DocumentCount must be greater than or equal to 0");
        }
    }
}
