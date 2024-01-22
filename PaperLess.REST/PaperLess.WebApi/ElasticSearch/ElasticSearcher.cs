using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Logging;
using PaperLess.Elastic.Interfaces;

namespace PaperLess.WebApi.ElasticSearch;

public class ElasticSearcher : IElasticSearcher
{
    private readonly ILogger<ElasticSearcher> _logger;

    public ElasticSearcher(ILogger<ElasticSearcher> logger) {
        _logger = logger;
    }

    IEnumerable<ElasticDoc> IElasticSearcher.SearchDocument(string searchTerm)
    {
        var elasticClient = new ElasticsearchClient(new Uri("http://paperless-elastic:9200"));

        var searchResponse = elasticClient.Search<ElasticDoc>(s => s
            .Index("documents")
            .Query(q => q.QueryString(qs => qs.DefaultField(p => p.Content).Query($"*{searchTerm}*"))));

        return searchResponse.Documents;
    }

}
