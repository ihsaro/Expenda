using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using MediatR;
using Expenda.Application.Architecture;
using Expenda.Application.Architecture.Localization;
using Expenda.Application.Architecture.Security;

namespace Expenda.Application.Features.Authentication.Commands;

public class VerifyUserCommand : IRequest<TransactionResult<VerifyUserCommandResponse>>
{
    [Required]
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [Required]
    [JsonPropertyName("password")]
    public required string Password { get; set; }
}

public class VerifyUserCommandResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }
}

public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, TransactionResult<VerifyUserCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationUserManager _userManager;
    private readonly IApplicationTokenManager _tokenManager;
    private readonly IAuthenticationMessenger _messenger;

    public VerifyUserCommandHandler(IMapper mapper, IApplicationUserManager userManager, IApplicationTokenManager tokenManager, IAuthenticationMessenger messenger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _tokenManager = tokenManager;
        _messenger = messenger;
    }

    public async Task<TransactionResult<VerifyUserCommandResponse>> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByUsernameAsync(request.Username);

        if (user is not null && await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return new TransactionResult<VerifyUserCommandResponse>(new VerifyUserCommandResponse { AccessToken = _tokenManager.GenerateAndGetToken(user) });
        }

        return new TransactionResult<VerifyUserCommandResponse>()
            .AddErrorMessage(new ErrorMessage(_messenger.GetMessage("INVALID_CREDENTIALS")));
    }
}