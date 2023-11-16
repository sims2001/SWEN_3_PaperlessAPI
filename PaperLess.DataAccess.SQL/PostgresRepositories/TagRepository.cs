using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories{

    public class TagRepository : ITagRepository
    {
        private readonly PaperLessDbContext _context;

        public TagRepository(PaperLessDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
    }

}