using Expenda.Application.Architecture;
using Expenda.Application.Models;
using Expenda.Application.Services.Interfaces;

namespace Expenda.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    public Task<TransactionResult<LoginResponse>> Login(LoginRequest request, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResult<RegistrationResponse>> Register(RegistrationRequest request, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}