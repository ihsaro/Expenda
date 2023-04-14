using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Entities;
using MediatR;

namespace Expenda.Application.Features.Authentication.Commands;

public class RegisterUserCommand : IRequest<TransactionResult<RegisterUserCommandResponse>>
{
    [Required]
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [Required]
    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    [Required]
    [JsonPropertyName("email_address")]
    public required string EmailAddress { get; set; }

    [Required]
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; set; }
}

public class RegisterUserCommandResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    [JsonPropertyName("email_address")]
    public required string EmailAddress { get; set; }

    [JsonPropertyName("username")]
    public required string Username { get; set; }
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, TransactionResult<RegisterUserCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IAuthenticationMessenger _messenger;

    public RegisterUserCommandHandler(IMapper mapper, IApplicationUserManager userManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _messenger = messenger;
    }

    public async Task<TransactionResult<RegisterUserCommandResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userManager.DoesUserExist(request.Username, request.EmailAddress))
        {
            return new TransactionResult<RegisterUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("USER_ALREADY_EXISTS")));
        }

        var user = _mapper.Map<ApplicationUser>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        return result.Success ?
            new TransactionResult<RegisterUserCommandResponse>(_mapper.Map<RegisterUserCommandResponse>(user)) :
            new TransactionResult<RegisterUserCommandResponse>().AddBatchErrorMessages(result.ErrorMessages);
    }
}