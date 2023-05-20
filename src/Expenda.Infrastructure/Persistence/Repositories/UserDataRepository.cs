using Dapper;
using Expenda.Domain.Entities.Derived;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class UserDataRepository : IUserDataRepository
{
    private readonly ApplicationDbContext _context;

    public UserDataRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDataMetrics> GetUserDataMetrics(int userId, CancellationToken token)
    {
        var query = $@"
                        SELECT
                            SUM(e.""Price"" * e.""Quantity"") AS TotalAmountSpent,
                            e_last.""Name"" AS LastItemPurchased,
                            e_last.""Quantity"" AS LastItemPurchasedQuantity,
                            (e_last.""Quantity"" * e_last.""Price"") AS LastItemPurchasedTotalPrice
                        FROM
                            public.""Expenses"" e
                        JOIN
                            (
                                SELECT
                                    ""Id"",
                                    ""Name"",
                                    ""Quantity"",
                                    ""Price""
                                FROM
                                    public.""Expenses""
                                ORDER BY
                                    ""LastUpdatedTimestamp"" DESC
                                LIMIT 1
                            ) e_last ON e.""Id"" = e_last.""Id""
                        WHERE
                            e.""ApplicationUser"" = @UserId
                        GROUP BY
                            e_last.""Name"",
                            e_last.""Quantity"",
                            e_last.""Price"";
                        ";

        using var connection = _context.Database.GetDbConnection();

        return await connection.QueryFirstAsync<UserDataMetrics>(query, new { UserId = userId });
    }
}