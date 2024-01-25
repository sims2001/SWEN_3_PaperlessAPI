using PaperLess.Elastic.Interfaces;

namespace PaperLess.BusinessLogic.Interfaces;

public interface ISearchLogic
{
    public IEnumerable<ElasticDoc> SearchDocument(string searchTerm);
}