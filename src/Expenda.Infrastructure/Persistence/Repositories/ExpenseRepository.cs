using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class ExpenseRepository : Repository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext context, IApplicationSessionManager session) : base(context, session)
    {
    }

    public async Task<IEnumerable<Expense>> GetExpensesByUserId(int userId, CancellationToken token = default)
    {
        return await Table
            .Where(x => x.OwnerId == userId)
            .ToListAsync(token);
    }

    public async Task<IEnumerable<Expense>> GetExpensesByIds(IEnumerable<int> ids, CancellationToken token = default)
    {
        return await Table
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(token);
    }
}