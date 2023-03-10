using AutoMapper;
using Expenda.Application.Models;
using Expenda.Domain.Entities;

namespace Expenda.Application.Mappers;

public class RegistrationRequestToApplicationUser : Profile
{
    public RegistrationRequestToApplicationUser()
    {
        CreateMap<RegistrationRequest, ApplicationUser>()
            .ForMember(src => src.Email, opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(src => src.UserName, opt => opt.MapFrom(src => src.Username));
    }
}
