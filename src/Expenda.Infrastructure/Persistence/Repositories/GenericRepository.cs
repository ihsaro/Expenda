using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

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

    public async Task<bool> Delete(int id, CancellationToken token = default)
    {
        try
        {
            var entity = await _table.FindAsync(new object?[] { id }, token);

            if (entity == null)
                return false;

            _table.Remove(entity);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<int> Commit(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token);
    }
}