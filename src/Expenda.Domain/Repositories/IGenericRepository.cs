using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    void BatchCreate(IEnumerable<T> entities);
    void Create(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<T?> GetById(int id, CancellationToken token = default);
    Task<int> Commit(CancellationToken token = default);
}