using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Expenda.Infrastructure.Security;

internal class ApplicationUserManager : IApplicationUserManager
{
    private readonly UserManager<IdentityUser<int>> _userManager;

    public ApplicationUserManager(UserManager<IdentityUser<int>> userManager)
    {
        _userManager = userManager;
    }

    public async Task<TransactionResult<ApplicationUser?>> CreateIdentityUser(ApplicationUser user, string password)
    {
        var identityUser = new IdentityUser<int>
        {
            Id = user.Id,
            UserName = user.Username,
            Email = user.EmailAddress
        };

        var result = await _userManager.CreateAsync(identityUser, password);

        if (result.Succeeded)
        {
            user.Id = identityUser.Id;
            user.CreatedById = identityUser.Id;
            user.LastUpdatedById = identityUser.Id;
            return new TransactionResult<ApplicationUser?>(user);
        }

        var transaction = new TransactionResult<ApplicationUser?>();
        result.Errors.ToList().ForEach(error => transaction.AddErrorMessage(new ErrorMessage(error.Code, error.Description)));
        return transaction;
    }

    public async Task<bool> DoesIdentityUserExist(string username, string email) => await _userManager.FindByNameAsync(username) is not null || await _userManager.FindByEmailAsync(email) is not null;

    public async Task<bool> ValidateIdentityUserCredentials(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password)) return false;
        return true;
    }
}
