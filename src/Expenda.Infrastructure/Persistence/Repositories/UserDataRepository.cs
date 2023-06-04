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
                            MAX(e_last.""Name"") AS LastItemPurchased,
                            MAX(e_last.""Quantity"") AS LastItemPurchasedQuantity,
                            MAX(e_last.""Quantity"" * e_last.""Price"") AS LastItemPurchasedTotalPrice
                        FROM
                            public.""Expenses"" e
                        JOIN
                            (
                                SELECT
                                    ""ApplicationUser"",
                                    ""Id"",
                                    ""Name"",
                                    ""Quantity"",
                                    ""Price""
                                FROM
                                    public.""Expenses""
                                WHERE
                                    ""ApplicationUser"" = @UserId
                                ORDER BY
                                    ""LastUpdatedTimestamp"" DESC
                                LIMIT 1
                            ) e_last ON e.""ApplicationUser"" = e_last.""ApplicationUser""
                        WHERE
                            e.""ApplicationUser"" = @UserId
                        GROUP BY
                            e.""ApplicationUser"";
                        ";

        using var connection = _context.Database.GetDbConnection();

        return await connection.QueryFirstAsync<UserDataMetrics>(query, new { UserId = userId });
    }
}