using Microsoft.Extensions.Logging;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.Elastic.Interfaces;

namespace PaperLess.BusinessLogic;

public class SearchLogic : ISearchLogic
{
    private readonly IElasticSearcher _searcher;
    private readonly ILogger<SearchLogic> _logger;

    public SearchLogic(IElasticSearcher searcher, ILogger<SearchLogic> logger)
    {
        _searcher = searcher;
        _logger = logger;
    }

    public IEnumerable<ElasticDoc> SearchDocument(string searchTerm)
    {
        _logger.LogInformation($"Searching for term: {searchTerm}");
        return _searcher.SearchDocument(searchTerm);
    }
}