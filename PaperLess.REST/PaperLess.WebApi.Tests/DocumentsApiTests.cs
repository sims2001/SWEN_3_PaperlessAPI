using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Interfaces;
using PaperLess.WebApi.Controllers;
using PaperLess.WebApi.Entities;
using Xunit;

namespace PaperLess.WebApi.Tests;

public class DocumentsApiTests
{
    [Fact]
    public async Task UploadDocument_InvalidRequest()
    {
        var invalidRequest = new CreateDocumentRequest();
        var errorList = new List<string> { "Invalid request error message" };
        
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Document>(invalidRequest)).Returns(new Document());
        
        var logicMock = new Mock<IDocumentLogic>();
        logicMock.Setup(l => l.CreateDocument(It.IsAny<Document>())).ReturnsAsync(new BusinessLogicResult { IsSuccess = false, Errors = errorList });
        
        var loggerMock = new Mock<ILogger<DocumentsApiController>>();
        
        var api = new DocumentsApiController(logicMock.Object, mapperMock.Object, loggerMock.Object);

        var result = await api.UploadDocument(invalidRequest);

        Assert.IsType<BadRequestObjectResult>(result);

        var objectResult = (BadRequestObjectResult)result;
        var val = objectResult.Value;
        
        Assert.Equal(errorList, ((List<string>)objectResult.Value.GetType().GetProperty("errors")?.GetValue(objectResult.Value)).ToList() ); 
        
        logicMock.Verify(l => l.CreateDocument(It.IsAny<Document>()), Times.Once);
    }
    
    [Fact]
    public async Task UploadDocument_ValidRequest()
    {
        var fileName = "Doc.pdf";
        var uploadFile = new FormFile(new MemoryStream(), 0, 0, "document", fileName);
        var validRequest = new CreateDocumentRequest
        {
            Title = fileName,
            Document = uploadFile
        };
        
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Document>(validRequest)).Returns(new Document
        {
            Title = fileName,
            UploadDocument = uploadFile
        });
        
        var logicMock = new Mock<IDocumentLogic>();
        logicMock.Setup(l => l.CreateDocument(It.IsAny<Document>())).ReturnsAsync(new BusinessLogicResult { IsSuccess = true });
        
        var loggerMock = new Mock<ILogger<DocumentsApiController>>();
        
        var api = new DocumentsApiController(logicMock.Object, mapperMock.Object, loggerMock.Object);

        var result = await api.UploadDocument(validRequest);

        Assert.IsType<OkResult>(result);
        
        logicMock.Verify(l => l.CreateDocument(It.IsAny<Document>()), Times.Once);
    }
    
    [Fact]
    public async Task UploadDocument_MappingException()
    {
        var request = new CreateDocumentRequest();
        var exMsg = "Error while Mapping the Request";
        
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Document>(request)).Throws(new AutoMapperMappingException(exMsg));
        var logicMock = new Mock<IDocumentLogic>();
        var loggerMock = new Mock<ILogger<DocumentsApiController>>();
        
        var api = new DocumentsApiController(logicMock.Object, mapperMock.Object, loggerMock.Object);

        var result = api.UploadDocument(request);
        
        Assert.IsType<BadRequestObjectResult>(result);
    }
}