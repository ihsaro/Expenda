using Expenda.Application.Architecture;
using Expenda.Application.Models;

namespace Expenda.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TransactionResult<RegistrationResponse>> Register(RegistrationRequest request, CancellationToken token = default);
    Task<TransactionResult<LoginResponse>> Login(LoginRequest request, CancellationToken token = default);
}