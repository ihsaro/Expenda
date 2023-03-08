using Expenda.Application.Architecture.Security.Models;
using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security.Managers;

public interface ITokenManager
{
    AccessTokenDefinition GetToken(ApplicationUser user);
}
