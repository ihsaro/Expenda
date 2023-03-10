using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    void BatchCreate(IEnumerable<T> entities, CancellationToken token = default);
    void Create(T entity, CancellationToken token = default);
    Task<bool> Delete(int id, CancellationToken token = default);
    Task<int> Commit(CancellationToken token = default);
}