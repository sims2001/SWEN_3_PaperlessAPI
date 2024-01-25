using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.Elastic.Interfaces;
using PaperLess.WebApi.Controllers;
using Xunit;

namespace PaperLess.WebApi.Tests;

public class SearchApiTests
{
    [Fact]
    public void SearchDocuments_NotFound()
    {
        var searchTerm = "world";
        var foundDoks = new List<ElasticDoc>();
        
        var searchLogicMock = new Mock<ISearchLogic>();
        searchLogicMock.Setup(e => e.SearchDocument(It.IsAny<string>())).Returns(foundDoks);

        var loggerMock = new Mock<ILogger<SearchApiController>>();

        var api = new SearchApiController(searchLogicMock.Object, loggerMock.Object);

        var result = api.SearchDocuments(searchTerm);

        // Assert the result is an ObjectResult
        Assert.IsType<ObjectResult>(result);

        var objectResult = (ObjectResult)result;
        Assert.Equal(foundDoks, objectResult.Value);
    }
    
    [Fact]
    public void SearchDocuments_Found()
    {
        var searchTerm = "world";
        var foundDoks = new List<ElasticDoc>()
        {
            new ElasticDoc() { Content = "HEllo World", Id = 7, Title = "Welt" },
            new ElasticDoc() { Content = "Hallooo World", Id = 6, Title = "Hallo" }
        };
        
        var searchLogicMock = new Mock<ISearchLogic>();
        searchLogicMock.Setup(e => e.SearchDocument(It.IsAny<string>())).Returns(foundDoks);

        var loggerMock = new Mock<ILogger<SearchApiController>>();

        var api = new SearchApiController(searchLogicMock.Object, loggerMock.Object);

        var result = api.SearchDocuments(searchTerm);

        // Assert the result is an ObjectResult
        Assert.IsType<ObjectResult>(result);

        var objectResult = (ObjectResult)result;
        Assert.Equal(foundDoks, objectResult.Value);
    }
}