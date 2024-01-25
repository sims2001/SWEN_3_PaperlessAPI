using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PaperLess.BusinessLogic.Entities;
using PaperLess.DataAccess.Entities;
using PaperLess.DataAccess.SQL;
using PaperLess.DataAccess.SQL.PostgresRepositories;
using Xunit;

namespace PaperLess.DataAccess.Tests;


[TestSubject(typeof(DocumentRepository))]
public class DocumentRepositoryTests
{
    [Fact]
    public void AddDocument_ShouldAddDocumentToDatabase()
    {
        var docTitle = "Test.pdf";
        var expectedId = 5;
        var document = new Document { Title = docTitle };

        var mockDok = new Mock<DbSet<DocumentDAL>>();

        var options = new DbContextOptions<PaperLessDbContext>();
        var contextMock = new Mock<PaperLessDbContext>(options);
        contextMock.Setup(m => m.Documents).Returns(mockDok.Object);
        
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<DocumentRepository>>();
        
        mapperMock.Setup(mapper => mapper.Map<DocumentDAL>(It.IsAny<Document>()))
            .Returns(new DocumentDAL { Id = expectedId, Title = docTitle });

        var dbService = new DocumentRepository(contextMock.Object, mapperMock.Object, loggerMock.Object);

        var result = dbService.AddDocument(document);
        
        mockDok.Verify(m => m.Add(It.IsAny<DocumentDAL>()), Times.Once);
        contextMock.Verify(c => c.SaveChanges(), Times.Once);
        
        Assert.Equal(expectedId, result);

    }
}