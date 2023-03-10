using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class MonthlyBudgetRepository : GenericRepository<MonthlyBudget>, IMonthlyBudgetRepository
{
    public MonthlyBudgetRepository(ApplicationDbContext context) : base(context)
    {
    }
}