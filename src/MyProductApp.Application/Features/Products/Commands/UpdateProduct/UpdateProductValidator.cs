using FluentValidation;

namespace MyProductApp.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
        RuleFor(x=> x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x=> x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be >= 0");
    }
}