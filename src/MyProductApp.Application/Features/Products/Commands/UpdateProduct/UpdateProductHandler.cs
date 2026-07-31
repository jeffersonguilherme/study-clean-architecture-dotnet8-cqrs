using MediatR;
using MyProductApp.Application.DTOs;
using MyProductApp.Application.Interfaces.Repositories;

namespace MyProductApp.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if(product is null)
            throw new ArgumentException("Product not found");

        product.UpdateName(request.Name);
        product.UpdatePrice(request.Price);
        

        await _repository.UpdateAsync(product, cancellationToken);

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}