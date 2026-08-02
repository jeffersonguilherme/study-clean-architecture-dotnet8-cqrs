using MediatR;
using MyProductApp.Application.DTOs.AuthDTO;
using MyProductApp.Application.Interfaces.Identity;
using MyProductApp.Application.Interfaces.Repositories;

namespace MyProductApp.Application.Features.Auth.Commands.RegisterUser;


public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IIdentityService _identityService;
    private readonly IMatriculaRoleRepository _matriculaRoleRepository;

    public RegisterUserHandler(IIdentityService identityService, IMatriculaRoleRepository matriculaRoleRepository)
    {
        _identityService = identityService;
        _matriculaRoleRepository = matriculaRoleRepository;
    }

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var matriculaRole = await _matriculaRoleRepository.GetByMatriculaAsync(request.Matricula, cancellationToken);

        if(matriculaRole is null)
            throw new Exception("Matricula não encontrada ou sem role associada");

        var (succeeded, userId, errors) = await _identityService.RegisterUserAsync(
            request.Email, request.Password, matriculaRole.Role, cancellationToken
        );

        if(!succeeded)
            throw new Exception(string.Join(", ", errors));

        return new RegisterUserResult
        {
            Id = userId!.Value,
            Email = request.Email
        }; 
    }
}