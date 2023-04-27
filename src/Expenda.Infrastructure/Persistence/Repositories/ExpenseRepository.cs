using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesForUser(int userId, CancellationToken token = default)
    {
        return await Table.Where(x => x.Owner.Id == userId).ToListAsync(cancellationToken: token);
    }
}