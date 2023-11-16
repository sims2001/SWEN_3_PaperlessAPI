using PaperLess.BusinessLogic.Entities;

namespace PaperLess.DataAccess.Interfaces;

public interface IDocumentRepository
{
    public Document GetById(int id);
    public IEnumerable<Document> GetAllDocuments();
    public void AddDocument(Document document);
    public void UpdateDocument(Document document);
    public void DeleteDocument(int id);
}
