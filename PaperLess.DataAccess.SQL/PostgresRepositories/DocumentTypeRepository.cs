using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories{

    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly PaperLessDbContext _context;

        public DocumentTypeRepository(PaperLessDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
    }

}