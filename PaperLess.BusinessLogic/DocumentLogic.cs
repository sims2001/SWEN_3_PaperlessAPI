using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;

namespace PaperLess.BusinessLogic {

    public class DocumentLogic : IDocumentLogic {
        public List<Document> GetDocuments(int? page, int? pageSize, string query, string ordering, List<int> tagsIdAll, int? documentTypeId,
            int? storagePathIdIn, int? correspondentId, bool? truncateContent) {
            throw new NotImplementedException();
        }

        public void CreateDocument(Document document) {
            throw new NotImplementedException();
        }

        public Document GetDocument(int id, int? page, bool? fullPerms) {
            throw new NotImplementedException();
        }

        public Document UpdateDocument(int id, Document document) {
            return document;
            throw new NotImplementedException();
        }

        public Document DeleteDocument(int id) {
            throw new NotImplementedException();
        }
    }

}