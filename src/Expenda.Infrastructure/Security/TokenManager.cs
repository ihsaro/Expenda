using Expenda.Application.Architecture.Security.Managers;
using Expenda.Application.Architecture.Security.Models;
using Expenda.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Expenda.Infrastructure.Security;

internal class TokenManager : ITokenManager
{
    private readonly IConfiguration _configuration;
    
    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AccessTokenDefinition GetToken(ApplicationUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AccessToken:Secret"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var expires = DateTime.Now.AddDays(1);

        var token = new JwtSecurityToken(
            _configuration["AccessToken:Issuer"],
            _configuration["AccessToken:Audience"],
            claims,
            expires: expires,
            signingCredentials: credentials
        );

        return new AccessTokenDefinition(new JwtSecurityTokenHandler().WriteToken(token), expires);
    }
}
