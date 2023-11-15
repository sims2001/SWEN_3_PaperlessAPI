using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface ICorrespondentLogic {

        public List<Correspondent> GetCorrespondents(int? page, bool? fullPerms);
        public BusinessLogicResult<Correspondent> CreateCorrespondent(Correspondent correspondent);
        public BusinessLogicResult<Correspondent> UpdateCorrespondent(int id, Correspondent correspondent);
        public void DeleteCorrespondent(int id);

    }

}