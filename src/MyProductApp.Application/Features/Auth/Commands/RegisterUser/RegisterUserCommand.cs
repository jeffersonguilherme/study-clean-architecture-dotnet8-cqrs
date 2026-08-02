using MediatR;
using MyProductApp.Application.DTOs.AuthDTO;

namespace MyProductApp.Application.Features.Auth.Commands.RegisterUser;

public record RegisterUserCommand(string Email, string Password, string Matricula) : IRequest<RegisterUserResult>;