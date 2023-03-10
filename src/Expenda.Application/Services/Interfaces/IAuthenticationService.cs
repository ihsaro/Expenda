using Expenda.Application.Architecture;
using Expenda.Application.Models;

namespace Expenda.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TransactionResult<bool>> RegisterUser(RegistrationRequest request, CancellationToken token = default);
    Task<bool> VerifyUserCredential(VerifyUserCredentialRequest request, CancellationToken token = default);
}