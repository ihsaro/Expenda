using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security;

public interface IApplicationUserManager
{
    Task<TransactionResult<ApplicationUser?>> CreateIdentityUser(ApplicationUser user, string password);
    Task<bool> DoesIdentityUserExist(string username, string email);
    Task<bool> ValidateIdentityUserCredentials(string username, string password);
}
