namespace Expenda.Application.Architecture.Security;

public interface IApplicationTokenManager
{
    string GenerateAndGetToken(string username);
}
