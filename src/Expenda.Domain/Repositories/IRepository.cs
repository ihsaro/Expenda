using Expenda.Domain.Entities.Base;

namespace Expenda.Domain.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Creates entities of generic type T into the repository context
    /// </summary>
    /// <param name="entities">Entities to be created</param>
    void BatchCreate(IEnumerable<T> entities);

    /// <summary>
    /// Creates entity of generic type T into the repository context
    /// </summary>
    /// <param name="entity">Entity to be created</param>
    void Create(T entity);

    /// <summary>
    /// Deletes entity of generic type T from the repository context
    /// </summary>
    /// <param name="entity">Entity to be deleted</param>
    void Delete(T entity);

    /// <summary>
    /// Deletes entities of generic type T from the repository context
    /// </summary>
    /// <param name="entities">Entities to be deleted</param>
    void BatchDelete(IEnumerable<T> entities);

    /// <summary>
    /// Updates an entity
    /// </summary>
    /// <param name="entity">Entity to be updated</param>
    void Update(T entity);

    /// <summary>
    /// Gets all entities of generic type T, while not loading the related entities within,
    /// so overriding this method is recomended in case related entities need to be loaded.
    /// </summary>
    /// <param name="take">Number of entities to be loaded (Default: 1000)</param>
    /// <param name="skip">Number of entities to be skipped (Default: 0)</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>IEnumerable of entities of type T</returns>
    Task<IEnumerable<T>> GetAllAsync(int take = 1000, int skip = 0, CancellationToken token = default);

    /// <summary>
    /// Gets 1 entity of generic type T based on an id, while not loading the related entities within,
    /// so overriding this method is recomended in case related entities need to be loaded.
    /// </summary>
    /// <param name="id">Id of the entity to be fetched</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>Entity of type T</returns>
    Task<T?> GetByIdAsync(int id, CancellationToken token = default);

    /// <summary>
    /// Commits every transaction from the context to the database.
    /// </summary>
    /// <param name="token">Cancellation token</param>
    /// <returns>Number of records affected</returns>
    Task<int> CommitAsync(CancellationToken token = default);
}