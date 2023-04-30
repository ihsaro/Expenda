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
    
    public void BatchCreate(IEnumerable<T> entities)
    {
        Table.AddRange(entities);
    }

    public void Create(T entity)
    {
        Table.Add(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }
    
    public void BatchDelete(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public async Task<T?> GetById(int id, CancellationToken token = default)
    {
        return await Table.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
    }

    public async Task<int> Commit(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token);
    }
}