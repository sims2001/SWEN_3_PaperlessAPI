using FluentValidation;
using FluentValidation.Results;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;

namespace PaperLess.BusinessLogic {

    public class TagLogic : ITagLogic {

        private readonly IValidator<Tag> _validator;

        public TagLogic(IValidator<Tag> validator) {
            _validator = validator;
        }


        public Tag GetTags(int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public Tag NewTag(Tag tag) {

            ValidationResult result = _validator.Validate(tag);
            Console.WriteLine("######################### PAUSEEEE ####################### \n \n \n ");
            Console.WriteLine( result.ToString() );

            if (result.IsValid)
                tag.Color = "didit!";
            else
                tag.Color = "nodidit";
            
            return tag;
            throw new NotImplementedException();
        }

        public Tag UpdateTag(int id, Tag tag) {
            throw new NotImplementedException();
        }

        public void DeleteTag(int id) {
            throw new NotImplementedException();
        }
    }

}