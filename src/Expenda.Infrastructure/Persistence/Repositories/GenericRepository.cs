using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<T> Table;

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        Table = _context.Set<T>();
    }
    
    public virtual void BatchCreate(IEnumerable<T> entities) => Table.AddRange(entities);

    public virtual void Create(T entity) => Table.Add(entity);

    public virtual void Delete(T entity) => Table.Remove(entity);
    
    public virtual void BatchDelete(IEnumerable<T> entities) => Table.RemoveRange(entities);

    public virtual async Task<IEnumerable<T>> GetAll(int take = 1000, int skip = 0, CancellationToken token = default)
        => await Table.Skip(skip).Take(take).ToListAsync(token);

    public virtual async Task<T?> GetById(int id, CancellationToken token = default)
        => await Table.FirstOrDefaultAsync(x => x.Id == id, token);

    public virtual async Task<int> Commit(CancellationToken token = default) => await _context.SaveChangesAsync(token);
}