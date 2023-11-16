using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories{

    public class DocumentRepository : IDocumentRepository
    {
        private readonly PaperLessDbContext _context;

        public DocumentRepository(PaperLessDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }

            
    }

}