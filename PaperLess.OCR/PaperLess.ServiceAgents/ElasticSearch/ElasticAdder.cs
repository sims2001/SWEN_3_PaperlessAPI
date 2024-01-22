using Elastic.Clients.Elasticsearch;
using PaperLess.Elastic.Interfaces;

namespace PaperLess.ServiceAgents.ElasticSearch;

public class ElasticAdder : IElasticAdder
{
    private readonly ILogger<ElasticAdder> _logger;

    public ElasticAdder(ILogger<ElasticAdder> logger) {
        _logger = logger;
    }

    public void AddDocToElastic(ElasticDoc document) {
        var elasticClient = new ElasticsearchClient(new Uri("http://paperless-elastic:9200"));

        if (!elasticClient.Indices.Exists("documents").Exists)
            elasticClient.Indices.Create("documents");

        var indexResponse = elasticClient.Index(document, "documents");
        if (!indexResponse.IsSuccess())
        {
            // Handle errors
            _logger.LogError($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");

            throw new Exception($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");
        }


    }
}
