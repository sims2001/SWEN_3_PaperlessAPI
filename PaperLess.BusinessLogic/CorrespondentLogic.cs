using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;

namespace PaperLess.BusinessLogic {
    public class CorrespondentLogic : ICorrespondentLogic {
        private readonly IValidator<Correspondent> _validator;
        public CorrespondentLogic(IValidator<Correspondent> validator) {
            _validator = validator;
        }

        public List<Correspondent> GetCorrespondents(int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public Correspondent CreateCorrespondent(Correspondent correspondent) {
            throw new NotImplementedException();
        }

        public Correspondent UpdateCorrespondent(int id, Correspondent correspondent) {
            throw new NotImplementedException();
        }

        public Correspondent DeleteCorrespondent(int id) {
            throw new NotImplementedException();
        }
    }
}
