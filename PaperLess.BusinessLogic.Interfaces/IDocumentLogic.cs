using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface IDocumentLogic {
        public List<Document> GetDocuments(int? page,int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId, int? storagePathIdIn, int? correspondentId, bool? truncateContent);
        public BusinessLogicResult CreateDocument(Document document);
        public BusinessLogicResult<Document> GetDocument(int id, int? page, bool? fullPerms);
        public BusinessLogicResult<Document> UpdateDocument(int id, Document document);
        public BusinessLogicResult DeleteDocument(int id);

    }

}