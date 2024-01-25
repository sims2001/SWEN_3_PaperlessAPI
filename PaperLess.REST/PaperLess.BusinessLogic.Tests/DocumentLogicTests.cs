using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using Moq;
using PaperLess.BusinessLogic.Entities;
using PaperLess.BusinessLogic.Validation;
using PaperLess.DataAccess.Interfaces;
using PaperLess.Queue.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace PaperLess.BusinessLogic.Tests;

[TestSubject(typeof(DocumentLogic))]
public class DocumentLogicTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DocumentLogicTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async Task CreateDocument_ValidDocument_Success()
    {
        var fileMock = new Mock<IFormFile>();
        
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        fileMock.Setup(f => f.OpenReadStream()).Returns(stream);
        fileMock.Setup(f => f.FileName).Returns(fileName);
        fileMock.Setup(f => f.ContentType).Returns("application/pdf");
        
        var file = fileMock.Object;
        
        var document = new Document
        {
            Title = "TestTitle",
            UploadDocument = file
        };
        
        var validatorMock = new Mock<IValidator<Document>>();
        validatorMock.Setup(v => v.Validate(It.IsAny<Document>())).Returns(new ValidationResult());

        var repositoryMock = new Mock<IDocumentRepository>();
        repositoryMock.Setup(r => r.AddDocument((It.IsAny<Document>()))).Returns(5);

        var publisherMock = new Mock<IQueueProducer>();

        var loggerMock = new Mock<ILogger<DocumentLogic>>();

        var minioMock = new Mock<IMinioClient>();
        minioMock.Setup(r => r.PutObjectAsync(It.IsAny<PutObjectArgs>(), It.IsAny<CancellationToken>())).Verifiable();

        var myDocumentLogic = new DocumentLogic(validatorMock.Object, repositoryMock.Object, loggerMock.Object,
            minioMock.Object, publisherMock.Object);

        var result = await myDocumentLogic.CreateDocument(document);

        Assert.True(result.IsSuccess);
        Assert.Empty(result.Errors);

        validatorMock.Verify(v => v.Validate(It.IsAny<Document>()), Times.Once);
        repositoryMock.Verify(r => r.AddDocument(It.IsAny<Document>()), Times.Once);
        
        publisherMock.Verify(p => p.PublishToQueue(It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public async Task CreateDocument_InValidDocument_NoSuccess()
    {
        var fileMock = new Mock<IFormFile>();
        
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        fileMock.Setup(f => f.OpenReadStream()).Returns(stream);
        fileMock.Setup(f => f.FileName).Returns(fileName);
        fileMock.Setup(f => f.ContentType).Returns("application/pdf");
        
        var file = fileMock.Object;
        
        var document = new Document
        {
            UploadDocument = file
        };

        var validationError = new ValidationResult();
        validationError.Errors = new List<ValidationFailure>() { new ValidationFailure("Title", "Title cannot be empty") };
        
        var validatorMock = new Mock<IValidator<Document>>();
        validatorMock.Setup(v => v.Validate(It.IsAny<Document>())).Returns(validationError);

        var repositoryMock = new Mock<IDocumentRepository>();
        repositoryMock.Setup(r => r.AddDocument((It.IsAny<Document>()))).Returns(5);

        var publisherMock = new Mock<IQueueProducer>();

        var loggerMock = new Mock<ILogger<DocumentLogic>>();

        var minioMock = new Mock<IMinioClient>();
        minioMock.Setup(r => r.PutObjectAsync(It.IsAny<PutObjectArgs>(), It.IsAny<CancellationToken>())).Verifiable();

        var myDocumentLogic = new DocumentLogic(validatorMock.Object, repositoryMock.Object, loggerMock.Object,
            minioMock.Object, publisherMock.Object);

        var result = await myDocumentLogic.CreateDocument(document);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Errors);

        validatorMock.Verify(v => v.Validate(It.IsAny<Document>()), Times.Once);
    }
}