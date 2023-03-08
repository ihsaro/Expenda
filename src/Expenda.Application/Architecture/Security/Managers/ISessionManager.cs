using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security.Managers;

public interface ISessionManager
{
    ApplicationUser CurrentUser { get; }
}
