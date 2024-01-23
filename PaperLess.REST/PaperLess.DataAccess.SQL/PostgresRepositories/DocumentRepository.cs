using AutoMapper;
using Microsoft.Extensions.Logging;
using PaperLess.BusinessLogic.Entities;
using PaperLess.DataAccess.Entities;
using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories{

    public class DocumentRepository : IDocumentRepository
    {
        private readonly PaperLessDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentRepository> _logger;

        public DocumentRepository(PaperLessDbContext context, IMapper mapper, ILogger<DocumentRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public int AddDocument(Document document)
        {
            var newDoc = _mapper.Map<DocumentDAL>(document);
            _context.Documents.Add(newDoc);
            _context.SaveChanges();

            _logger.LogInformation($"Saved Doc with Id: {newDoc.Id} to Database");

            return (int) newDoc.Id;
        }

        public void DeleteDocument(int id)
        {
            var doc = _context.Documents.Find(id);
            if(doc != null){
                _context.Documents.Remove(doc);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            var dalDocs = _context.Documents.ToList();
            var businessDocs = _mapper.Map<List<Document>>(dalDocs);

            return businessDocs;
        }

        public Document GetById(int id)
        {
            var doc = _context.Documents.Find(id);
            
            return _mapper.Map<Document>(doc);
        }

        public void UpdateDocument(Document document)
        {
            var doc = _context.Documents.Find(document.Id);
            if(doc != null){
                doc = _mapper.Map<DocumentDAL>(document);

                _context.SaveChanges();
            }
        }
    }

}