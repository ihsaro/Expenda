using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class MonthlyBudgetRepository : GenericRepository<MonthlyBudget>, IMonthlyBudgetRepository
{
    public MonthlyBudgetRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<MonthlyBudget?> GetForUserByMonthAndYear(int id, int month, int year, CancellationToken token = default)
    {
        return await Table
            .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Owner.Id == id && x.Month == month && x.Year == year, token);
    }

    public async Task<IEnumerable<MonthlyBudget>> ListForUser(int id, CancellationToken token)
    {
        return await Table.Where(x => x.Owner.Id == id).ToListAsync(token);
    }
}