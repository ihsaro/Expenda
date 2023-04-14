﻿using Expenda.Application.Architecture.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Expenda.Domain.Entities;

namespace Expenda.Infrastructure.Security;

public class ApplicationTokenManager : IApplicationTokenManager
{
    private readonly IConfiguration _configuration;

    public ApplicationTokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAndGetToken(ApplicationUser user)
    {
        var issuer = _configuration["AccessToken:Issuer"];
        var audience = _configuration["AccessToken:Audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["AccessToken:Secret"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
