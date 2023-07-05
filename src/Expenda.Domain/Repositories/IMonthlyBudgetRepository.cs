using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IMonthlyBudgetRepository : IGenericRepository<MonthlyBudget>
{
    Task<MonthlyBudget?> GetForUserByMonthAndYear(int id, int month, int year, CancellationToken token = default);
    Task<IEnumerable<MonthlyBudget>> ListForUser(int id, CancellationToken token);
}