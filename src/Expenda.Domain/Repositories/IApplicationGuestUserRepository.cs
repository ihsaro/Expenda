using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IApplicationGuestUserRepository
{
    Task<int> CreateUser(ApplicationUser user, CancellationToken token);
    Task<ApplicationUser?> GetUser(string username, CancellationToken token);
}
