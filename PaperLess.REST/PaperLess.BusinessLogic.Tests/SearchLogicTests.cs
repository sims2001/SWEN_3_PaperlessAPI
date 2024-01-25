using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using PaperLess.BusinessLogic.Interfaces.BlExceptions;
using PaperLess.Elastic.Interfaces;
using Xunit;

namespace PaperLess.BusinessLogic.Tests;

public class SearchLogicTests
{
    [Fact]
    public void SearchDocument_FoundNothing()
    {
        var elasticMock = new Mock<IElasticSearcher>();
        elasticMock.Setup(e => e.SearchDocument(It.IsAny<string>())).Returns(new List<ElasticDoc>());

        var loggerMock = new Mock<ILogger<SearchLogic>>();

        var searchLogic = new SearchLogic(elasticMock.Object, loggerMock.Object);

        var result = searchLogic.SearchDocument("Hello World");
        Assert.Empty(result);
    }
    
    [Fact]
    public void SearchDocument_FoundSomething()
    {
        var returnDok = new ElasticDoc() { Content = "Hello World", Id = 7, Title = "Der Titel" };
        var elasticMock = new Mock<IElasticSearcher>();
        elasticMock.Setup(e => e.SearchDocument(It.IsAny<string>())).Returns(new List<ElasticDoc>() { returnDok } );

        var loggerMock = new Mock<ILogger<SearchLogic>>();

        var searchLogic = new SearchLogic(elasticMock.Object, loggerMock.Object);

        var result = searchLogic.SearchDocument("Hello World");
        Assert.NotEmpty(result);
        Assert.Equal(result.First(), returnDok);
        
    }
    
    [Fact]
    public void SearchDocument_BlException()
    {
        var expectedExceptionMessage = "Simulated exception message";

        var elasticMock = new Mock<IElasticSearcher>();
        elasticMock.Setup(e => e.SearchDocument(It.IsAny<string>())).Throws(new InvalidOperationException(expectedExceptionMessage));
        var loggerMock = new Mock<ILogger<SearchLogic>>();
        var searchLogic = new SearchLogic(elasticMock.Object, loggerMock.Object);

        Assert.ThrowsAny<BlExceptionBase>(() => searchLogic.SearchDocument("searchTerm"));
    }
}