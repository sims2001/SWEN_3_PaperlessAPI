using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface ICorrespondentLogic {

        public List<Correspondent> GetCorrespondents(int? page, bool? fullPerms);
        public Correspondent CreateCorrespondent(Correspondent correspondent);
        public Correspondent UpdateCorrespondent(int id, Correspondent correspondent);
        public Correspondent DeleteCorrespondent(int id);

    }

}