using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories;

public class CorrespondentRepository : ICorrespondentRepository
{
    private readonly PaperLessDbContext _context;

    public CorrespondentRepository(PaperLessDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
    }
}
