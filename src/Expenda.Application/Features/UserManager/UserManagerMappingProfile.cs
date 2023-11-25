using AutoMapper;
using Expenda.Application.Features.UserManager.Commands;
using Expenda.Application.Features.UserManager.Queries;
using Expenda.Domain.Entities;
using Expenda.Domain.Entities.Derived;

namespace Expenda.Application.Features.UserManager;

public class UserManagerMappingProfile : Profile
{
    public UserManagerMappingProfile()
    {
        CreateMap<RegisterUserCommand, ApplicationUser>();
        CreateMap<ApplicationUser, RegisterUserCommandResponse>();
        CreateMap<UserDataMetrics, GetUserDataMetricsResponse>();
    }
}
