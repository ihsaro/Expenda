using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security;

public interface IApplicationUserManager
{
    Task<TransactionResult<bool>> CreateAsync(ApplicationUser user, string password);
    Task<ApplicationUser?> FindByUsernameAsync(string username);
    Task<ApplicationUser?> FindByIdAsync(int id);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<bool> DoesUserExist(string username, string email);
}
