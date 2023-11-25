using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security;

public interface IApplicationUserManager
{
    Task<TransactionResult<ApplicationUser?>> CreateAsync(ApplicationUser user, string password);
    Task<bool> DoesUserExist(string username, string email);
    Task<bool> ValidateUserCredentials(string username, string password);
}
