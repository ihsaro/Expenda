using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext context) : base(context)
    {
    }
}