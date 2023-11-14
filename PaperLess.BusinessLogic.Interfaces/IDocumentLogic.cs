using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface IDocumentLogic {
        public List<Document> GetDocuments(int? page,int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId, int? storagePathIdIn, int? correspondentId, bool? truncateContent);
        public void CreateDocument(Document document);
        public Document GetDocument(int id, int? page, bool? fullPerms);
        public Document UpdateDocument(int id, Document document);
        public Document DeleteDocument(int id);

    }

}