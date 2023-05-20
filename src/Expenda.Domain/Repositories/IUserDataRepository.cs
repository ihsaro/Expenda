using Expenda.Domain.Entities.Derived;

namespace Expenda.Domain.Repositories;

public interface IUserDataRepository
{
    Task<UserDataMetrics> GetUserDataMetrics(int userId, CancellationToken token = default);
}