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
        CreateMap<RegisterUserCommand, ApplicationUser>()
            .ForMember(src => src.Email, opt => opt.MapFrom(dest => dest.EmailAddress))
            .ForMember(src => src.UserName, opt => opt.MapFrom(dest => dest.Username));

        CreateMap<ApplicationUser, RegisterUserCommandResponse>()
            .ForCtorParam("EmailAddress", opt => opt.MapFrom(dest => dest.Email))
            .ForCtorParam("Username", opt => opt.MapFrom(dest => dest.UserName));

        CreateMap<UserDataMetrics, GetUserDataMetricsResponse>();
    }
}
