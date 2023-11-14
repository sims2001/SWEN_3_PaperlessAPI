using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface ITagLogic {
        public Tag GetTags(int? page, bool? fullPerms);
        public Tag NewTag(Tag tag);
        public Tag UpdateTag(int id, Tag tag);
        public void DeleteTag(int id);
    }

}