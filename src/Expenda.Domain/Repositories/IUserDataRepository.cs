namespace Expenda.Domain.Repositories;

public interface IUserDataRepository
{
    Task<(float, float)> GetUserDataMetrics(CancellationToken token = default);
}