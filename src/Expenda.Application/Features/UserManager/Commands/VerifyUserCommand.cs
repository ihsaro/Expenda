using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
using Expenda.Domain.Repositories;
using MediatR;

namespace Expenda.Application.Features.UserManager.Commands;

public class VerifyUserCommand : IRequest<TransactionResult<VerifyUserCommandResponse>>
{
    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}

public record VerifyUserCommandResponse([property: JsonPropertyName("access_token")] string AccessToken);

public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, TransactionResult<VerifyUserCommandResponse>>
{
    private readonly IApplicationGuestUserRepository _applicationGuestUserRepository;
    private readonly IApplicationUserManager _userManager;
    private readonly IApplicationTokenManager _tokenManager;
    private readonly IAuthenticationLocalizationMessenger _messenger;

    public VerifyUserCommandHandler(IApplicationGuestUserRepository applicationGuestUserRepository, IApplicationUserManager userManager, IApplicationTokenManager tokenManager, IAuthenticationLocalizationMessenger messenger)
    {
        _applicationGuestUserRepository = applicationGuestUserRepository;
        _userManager = userManager;
        _tokenManager = tokenManager;
        _messenger = messenger;
    }

    public async Task<TransactionResult<VerifyUserCommandResponse>> Handle(VerifyUserCommand request, CancellationToken token)
    {
        if (!await _userManager.ValidateUserCredentials(request.Username, request.Password))
        {
            return new TransactionResult<VerifyUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("INVALID_CREDENTIALS")));
        }

        var user = await _applicationGuestUserRepository.GetUser(request.Username, token);
        
        if (user is null)
        {
            return new TransactionResult<VerifyUserCommandResponse>()
                .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("USER_PROFILE_DOES_NOT_EXIST")));
        }

        return new TransactionResult<VerifyUserCommandResponse>(new VerifyUserCommandResponse(_tokenManager.GenerateAndGetToken(user)));
    }
}