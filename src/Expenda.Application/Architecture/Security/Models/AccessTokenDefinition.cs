namespace Expenda.Application.Architecture.Security.Models;

public class AccessTokenDefinition
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }

    public AccessTokenDefinition(string accessToken, DateTime expiresAt)
    {
        AccessToken = accessToken;
        ExpiresAt = expiresAt;
    }
}
