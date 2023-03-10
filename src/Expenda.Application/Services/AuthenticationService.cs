using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;
using Expenda.Domain.Entities;

namespace Expenda.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IApplicationUserManager _userManager;

    public AuthenticationService(IApplicationUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> VerifyUserCredential(VerifyUserCredentialRequest request, CancellationToken token = default)
    {
        var user = await _userManager.FindByUsernameAsync(request.Username);
        return user == null || !await _userManager.CheckPasswordAsync(user, request.Password);
    }

    public async Task<TransactionResult<RegistrationResponse>> RegisterUser(RegistrationRequest request, CancellationToken token = default)
    {
        var result = await _userManager.CreateAsync(
            new ApplicationUser() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                Email = request.EmailAddress},
            request.Password
        );

        throw new NotImplementedException();
    }
}