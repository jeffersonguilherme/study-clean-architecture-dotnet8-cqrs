using FluentValidation;

namespace MyProductApp.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x=>x.Email).NotEmpty().WithMessage("O E-mail é obrigatório").EmailAddress().WithMessage("E-amil em formato inválido");
        RuleFor(x=> x.Password).NotEmpty().WithMessage("A senha é obrigatória.").MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        RuleFor(x=>x.Matricula).NotEmpty().WithMessage("A matrícula é obrigatória.");
    }
}