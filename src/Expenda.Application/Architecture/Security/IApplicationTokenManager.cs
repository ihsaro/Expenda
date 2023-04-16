using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security;

public interface IApplicationTokenManager
{
    string GenerateAndGetToken(ApplicationUser user);
    bool IsTokenValid(string token);
}
