using System.Reflection.Metadata;

namespace PaperLess.Elastic.Interfaces{

    public interface IElasticSearcher {
        IEnumerable<ElasticDoc> SearchDocument(string searchTerm);
    }

}