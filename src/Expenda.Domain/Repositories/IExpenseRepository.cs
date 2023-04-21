using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IExpenseRepository : IGenericRepository<Expense>
{
    Task<IEnumerable<Expense>> GetAllExpensesForUser(int userId, CancellationToken token = default);
}