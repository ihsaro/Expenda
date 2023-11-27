using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.UserManager.Commands;

public class RegisterUserCommand : IRequest<TransactionResult<RegisterUserCommandResponse>>
{
    [Required]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = null!;

    [Required]
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = null!;

    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}

public record RegisterUserCommandResponse
(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("first_name")] string FirstName,
    [property: JsonPropertyName("last_name")] string LastName,
    [property: JsonPropertyName("email_address")] string EmailAddress,
    [property: JsonPropertyName("username")] string Username
);

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TransactionResult<RegisterUserCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationGuestUserRepository _applicationGuestUserRepository;
    private readonly IApplicationUserManager _applicationUserManager;
    private readonly IAuthenticationLocalizationMessenger _authenticationLocalizationMessenger;

    public RegisterUserCommandHandler(IMapper mapper,
                                      IApplicationGuestUserRepository applicationGuestUserRepository,
                                      IApplicationUserManager applicationUserManager,
                                      IAuthenticationLocalizationMessenger authenticationLocalizationMessenger)
    {
        _mapper = mapper;
        _applicationGuestUserRepository = applicationGuestUserRepository;
        _applicationUserManager = applicationUserManager;
        _authenticationLocalizationMessenger = authenticationLocalizationMessenger;
    }

    public async Task<TransactionResult<RegisterUserCommandResponse>> Handle(RegisterUserCommand request, CancellationToken token)
    {
        if (await _applicationUserManager.DoesIdentityUserExist(request.Username, request.EmailAddress))
        {
            return new TransactionResult<RegisterUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_authenticationLocalizationMessenger.GetMessage("USER_ALREADY_EXISTS")));
        }

        var identityResult = await _applicationUserManager.CreateIdentityUser(_mapper.Map<ApplicationUser>(request), request.Password);

        if (!identityResult.Success || identityResult.ResultObject is null)
        {
            return new TransactionResult<RegisterUserCommandResponse>().AddBatchErrorMessages(identityResult.ErrorMessages);
        }

        var applicationUser = identityResult.ResultObject;

        var applicationUserCreationResult = await _applicationGuestUserRepository.CreateUser(applicationUser, token);

        if (applicationUserCreationResult != 1)
        {
            return new TransactionResult<RegisterUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_authenticationLocalizationMessenger.GetMessage("APPLICATION_USER_NOT_CREATED")));
        }

        return new TransactionResult<RegisterUserCommandResponse>(_mapper.Map<RegisterUserCommandResponse>(applicationUser));
    }
}
