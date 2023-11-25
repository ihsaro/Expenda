using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expenda.Infrastructure.Persistence.Repositories;

internal class ApplicationGuestUserRepository : IApplicationGuestUserRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicationGuestUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateUser(ApplicationUser user, CancellationToken token)
    {
        await _context.ApplicationUsers.AddAsync(user, token);
        return await _context.SaveChangesAsync(token);
    }

    public async Task<ApplicationUser?> GetUser(string username, CancellationToken token)
    {
        return await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Username.Equals(username), token);
    }
}
