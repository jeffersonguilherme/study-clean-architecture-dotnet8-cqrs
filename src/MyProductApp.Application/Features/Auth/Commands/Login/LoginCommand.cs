using MediatR;
using MyProductApp.Application.DTOs.AuthDTO;

namespace MyProductApp.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResult>;