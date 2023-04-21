using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _table;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    
    public void BatchCreate(IEnumerable<T> entities, CancellationToken token = default)
    {
        _table.AddRange(entities);
    }

    public void Create(T entity, CancellationToken token = default)
    {
        _table.Add(entity);
    }

    public void Delete(T entity, CancellationToken token = default)
    {
        _table.Remove(entity);
    }

    public async Task<T?> GetById(int id, CancellationToken token = default)
    {
        return await _table.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Commit(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token);
    }
}