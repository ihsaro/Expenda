using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    private readonly IApplicationSessionManager _sessionManager;
    
    public ExpenseRepository(IApplicationSessionManager sessionManager, ApplicationDbContext context) : base(context)
    {
        _sessionManager = sessionManager;
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesForUser(int userId, CancellationToken token = default)
    {
        return await _table.Where(x => x.Owner.Id == userId).ToListAsync();
    }
}