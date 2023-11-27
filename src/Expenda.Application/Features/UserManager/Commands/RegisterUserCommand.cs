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
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationLocalizationMessenger _messenger;

    public RegisterUserCommandHandler(IMapper mapper,
                                      IApplicationGuestUserRepository applicationGuestUserRepository,
                                      IApplicationUserManager userManager,
                                      IAuthenticationLocalizationMessenger messenger)
    {
        _mapper = mapper;
        _applicationGuestUserRepository = applicationGuestUserRepository;
        _userManager = userManager;
        _messenger = messenger;
    }

    public async Task<TransactionResult<RegisterUserCommandResponse>> Handle(RegisterUserCommand request, CancellationToken token)
    {
        if (await _userManager.DoesUserExist(request.Username, request.EmailAddress))
        {
            return new TransactionResult<RegisterUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("USER_ALREADY_EXISTS")));
        }

        var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(request), request.Password);

        if (!result.Success || result.ResultObject is null)
        {
            return new TransactionResult<RegisterUserCommandResponse>().AddBatchErrorMessages(result.ErrorMessages);
        }

        await _applicationGuestUserRepository.CreateUser(result.ResultObject, token);

        return new TransactionResult<RegisterUserCommandResponse>(_mapper.Map<RegisterUserCommandResponse>(result.ResultObject));
    }
}
