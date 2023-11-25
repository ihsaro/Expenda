using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class MonthlyBudgetRepository : Repository<MonthlyBudget>, IMonthlyBudgetRepository
{
    public MonthlyBudgetRepository(ApplicationDbContext context, IApplicationSessionManager session) : base(context, session)
    {
    }

    public async Task<MonthlyBudget?> GetForUserByMonthAndYear(int id, int month, int year, CancellationToken token = default)
    {
        return await Table
            .FirstOrDefaultAsync(x => x.OwnerId == id && x.Month == month && x.Year == year, token);
    }

    public async Task<IEnumerable<MonthlyBudget>> ListForUser(int id, CancellationToken token)
    {
        return await Table.Where(x => x.OwnerId == id).ToListAsync(token);
    }
}