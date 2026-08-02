using MediatR;
using MyProductApp.Application.DTOs.AuthDTO;

namespace MyProductApp.Application.Features.Auth.Commands.RegisterUser;


public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    public Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}