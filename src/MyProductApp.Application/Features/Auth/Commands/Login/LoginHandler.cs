using MediatR;
using MyProductApp.Application.DTOs.AuthDTO;
using MyProductApp.Application.Interfaces.Identity;

namespace MyProductApp.Application.Features.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public LoginHandler(IIdentityService identityService, ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var(succeeded, userId, email, roles) = await _identityService.ValidateCredentialsAsync(
            request.Email, request.Password, cancellationToken
        );

        if(!succeeded)
            throw new Exception("E-mail ou senha inválidos");

        var token = _tokenService.GenerateToken(userId!.Value, email!, roles);

        return new LoginResult
        {
            Token = token,
            UserId = userId.Value,
            Email = email!
        };

    }   
}