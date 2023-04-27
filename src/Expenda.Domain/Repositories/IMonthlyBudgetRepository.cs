using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IMonthlyBudgetRepository : IGenericRepository<MonthlyBudget>
{
    Task<MonthlyBudget?> GetByMonthAndYear(int month, int year, CancellationToken token = default);
    Task<IEnumerable<MonthlyBudget>> GetForUser(int id, CancellationToken token);
}