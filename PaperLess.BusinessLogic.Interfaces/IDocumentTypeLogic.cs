using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface IDocumentTypeLogic {
        public List<DocumentType> GetDocumentTypes(int? page, bool? fullPerms);
        public DocumentType CreateDocumentType(DocumentType documentType);
        public DocumentType UpdateDocumentType(int id,  DocumentType documentType);
        public DocumentType DeleteDocumentType(int id);

    }

}