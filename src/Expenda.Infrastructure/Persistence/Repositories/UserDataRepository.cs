using Expenda.Domain.Repositories;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class UserDataRepository : IUserDataRepository
{
    private readonly ApplicationDbContext _context;

    public UserDataRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task<(float, float)> GetUserDataMetrics(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}