using Expenda.Domain.Entities;

namespace Expenda.Domain.Repositories;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<IEnumerable<Expense>> GetExpensesByUserId(int userId, CancellationToken token = default);
    Task<IEnumerable<Expense>> GetExpensesByIds(IEnumerable<int> ids, CancellationToken token = default);
}