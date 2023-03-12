using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Security;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;
using Expenda.Domain.Entities;

namespace Expenda.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;

    public AuthenticationService(IMapper mapper, IApplicationUserManager userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<bool> VerifyUserCredential(VerifyUserCredentialRequest request, CancellationToken token = default)
    {
        var user = await _userManager.FindByUsernameAsync(request.Username);
        return user != null && await _userManager.CheckPasswordAsync(user, request.Password);
    }

    public async Task<TransactionResult<bool>> RegisterUser(RegistrationRequest request, CancellationToken token = default)
        => await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(request), request.Password);
}