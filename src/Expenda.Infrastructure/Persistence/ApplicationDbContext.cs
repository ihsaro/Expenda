using Microsoft.EntityFrameworkCore;
using Expenda.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Expenda.Domain.Entities.Base;

namespace Expenda.Infrastructure.Persistence;

internal class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<MonthlyBudget> MonthlyBudgets => Set<MonthlyBudget>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        var entries = ChangeTracker
                        .Entries()
                        .Where(e => e is { Entity: AuditableBaseEntity, State: EntityState.Added or EntityState.Modified });

        foreach (var entry in entries)
        {
            ((AuditableBaseEntity)entry.Entity).LastUpdatedTimestamp = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((AuditableBaseEntity)entry.Entity).CreatedTimestamp = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(token);
    }
}