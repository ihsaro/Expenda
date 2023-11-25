using Expenda.Domain.Entities;

namespace Expenda.Application.Architecture.Security;

public interface IApplicationSessionManager
{
    int CurrentUserId { get; }
}
