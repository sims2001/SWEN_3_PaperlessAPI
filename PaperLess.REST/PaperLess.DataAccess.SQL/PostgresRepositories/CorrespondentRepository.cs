using AutoMapper;
using Microsoft.Extensions.Logging;
using PaperLess.DataAccess.Interfaces;

namespace PaperLess.DataAccess.SQL.PostgresRepositories;

public class CorrespondentRepository : ICorrespondentRepository
{
    private readonly PaperLessDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CorrespondentRepository> _logger;

    public CorrespondentRepository(PaperLessDbContext context, IMapper mapper, ILogger<CorrespondentRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
    }
}
