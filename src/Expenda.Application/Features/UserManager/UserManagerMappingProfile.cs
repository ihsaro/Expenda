using AutoMapper;
using Expenda.Application.Features.UserManager.Queries;
using Expenda.Domain.Entities.Derived;

namespace Expenda.Application.Features.UserManager;

public class UserManagerMappingProfile : Profile
{
    public UserManagerMappingProfile()
    {
        CreateMap<UserDataMetrics, GetUserDataMetricsResponse>();
    }
}
