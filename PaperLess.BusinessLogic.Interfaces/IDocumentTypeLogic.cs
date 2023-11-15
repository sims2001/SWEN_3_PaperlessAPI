using PaperLess.BusinessLogic.Entities;

namespace PaperLess.BusinessLogic.Interfaces {

    public interface IDocumentTypeLogic {
        public List<DocumentType> GetDocumentTypes(int? page, bool? fullPerms);
        public BusinessLogicResult<DocumentType> CreateDocumentType(DocumentType documentType);
        public BusinessLogicResult<DocumentType> UpdateDocumentType(int id,  DocumentType documentType);
        public void DeleteDocumentType(int id);

    }

}