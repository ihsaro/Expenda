using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    void BatchCreate(IEnumerable<T> entities);
    void Create(T entity);
    void Delete(T entity);
    void BatchDelete(IEnumerable<T> entities);
    Task<IEnumerable<T>> GetAll(int take = 1000, int skip = 0, CancellationToken token = default);
    Task<T?> GetById(int id, CancellationToken token = default);
    Task<int> Commit(CancellationToken token = default);
}