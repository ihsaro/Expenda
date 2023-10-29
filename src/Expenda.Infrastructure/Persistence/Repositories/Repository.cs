using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities.Base;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly IApplicationSessionManager _session;
    protected readonly DbSet<T> Table;

    protected Repository(ApplicationDbContext context, IApplicationSessionManager session)
    {
        _context = context;
        _session = session;
        Table = _context.Set<T>();
    }

    /// <summary>
    /// Creates entities of generic type T into the repository context
    /// </summary>
    /// <param name="entities">Entities to be created</param>
    public virtual void BatchCreate(IEnumerable<T> entities)
    {
        foreach (var entity in entities.OfType<AuditableBaseEntity>())
        {
            entity.CreatedBy = _session.CurrentUser;
            entity.LastUpdatedBy = _session.CurrentUser;
        }

        Table.AddRange(entities);
    }

    /// <summary>
    /// Creates entity of generic type T into the repository context
    /// </summary>
    /// <param name="entity">Entity to be created</param>
    public virtual void Create(T entity)
    {
        if (entity is AuditableBaseEntity aEntity)
        {
            aEntity.CreatedBy = _session.CurrentUser;
            aEntity.LastUpdatedBy = _session.CurrentUser;
        }

        Table.Add(entity);
    }

    /// <summary>
    /// Deletes entity of generic type T from the repository context
    /// </summary>
    /// <param name="entity">Entity to be deleted</param>
    public virtual void Delete(T entity)
        => Table.Remove(entity);

    /// <summary>
    /// Deletes entities of generic type T from the repository context
    /// </summary>
    /// <param name="entities">Entities to be deleted</param>
    public virtual void BatchDelete(IEnumerable<T> entities)
        => Table.RemoveRange(entities);

    /// <summary>
    /// Updates an entity
    /// </summary>
    /// <param name="entity">Entity to be updated</param>
    public virtual void Update(T entity)
    {
        if (entity is AuditableBaseEntity aEntity)
        {
            aEntity.LastUpdatedBy = _session.CurrentUser;
        }

        Table.Update(entity);
    }

    /// <summary>
    /// Gets all entities of generic type T, while not loading the related entities within,
    /// so overriding this method is recomended in case related entities need to be loaded.
    /// </summary>
    /// <param name="take">Number of entities to be loaded (Default: 1000)</param>
    /// <param name="skip">Number of entities to be skipped (Default: 0)</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>IEnumerable of entities of type T</returns>
    public virtual async Task<IEnumerable<T>> GetAllAsync(int take = 1000, int skip = 0, CancellationToken token = default)
        => await Table.Skip(skip).Take(take).ToListAsync(token);

    /// <summary>
    /// Gets 1 entity of generic type T based on an id, while not loading the related entities within,
    /// so overriding this method is recomended in case related entities need to be loaded.
    /// </summary>
    /// <param name="id">Id of the entity to be fetched</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>Entity of type T</returns>
    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken token = default)
        => await Table.FirstOrDefaultAsync(x => x.Id == id, token);

    /// <summary>
    /// Commits every transaction from the context to the database.
    /// </summary>
    /// <param name="token">Cancellation token</param>
    /// <returns>Number of records affected</returns>
    public virtual async Task<int> CommitAsync(CancellationToken token = default)
        => await _context.SaveChangesAsync(token);
}