using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Expenda.Infrastructure.Security;

internal class ApplicationUserManager : IApplicationUserManager
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserManager(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<TransactionResult<bool>> CreateAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            return new TransactionResult<bool>(true);
        }

        var transaction = new TransactionResult<bool>(false);
        result.Errors.ToList().ForEach(error => transaction.AddErrorMessage(new ErrorMessage(error.Code, error.Description)));
        return transaction;
    }

    public async Task<ApplicationUser?> FindByUsernameAsync(string username) => await _userManager.FindByNameAsync(username);

    public async Task<ApplicationUser?> FindByIdAsync(int id) => await _userManager.FindByIdAsync(id.ToString());

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password) => await _userManager.CheckPasswordAsync(user, password);

    public async Task<bool> DoesUserExist(string username, string email) => await _userManager.FindByNameAsync(username) is not null || await _userManager.FindByEmailAsync(email) is not null;
}
