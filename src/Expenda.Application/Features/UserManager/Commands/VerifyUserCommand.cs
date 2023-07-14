using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;
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
    private readonly IApplicationUserManager _userManager;
    private readonly IApplicationTokenManager _tokenManager;
    private readonly IAuthenticationMessenger _messenger;

    public VerifyUserCommandHandler(IApplicationUserManager userManager, IApplicationTokenManager tokenManager, IAuthenticationMessenger messenger)
    {
        _userManager = userManager;
        _tokenManager = tokenManager;
        _messenger = messenger;
    }

    public async Task<TransactionResult<VerifyUserCommandResponse>> Handle(VerifyUserCommand request, CancellationToken token)
    {
        var user = await _userManager.FindByUsernameAsync(request.Username);

        if (user is not null && await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return new TransactionResult<VerifyUserCommandResponse>(new VerifyUserCommandResponse(_tokenManager.GenerateAndGetToken(user)));
        }

        return new TransactionResult<VerifyUserCommandResponse>()
            .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("INVALID_CREDENTIALS")));
    }
}