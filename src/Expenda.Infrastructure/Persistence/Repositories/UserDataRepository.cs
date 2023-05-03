using Expenda.Domain.Entities.Derived;
using Expenda.Domain.Repositories;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class UserDataRepository : IUserDataRepository
{
    private readonly ApplicationDbContext _context;

    public UserDataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    Task<UserDataMetrics> IUserDataRepository.GetUserDataMetrics(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}