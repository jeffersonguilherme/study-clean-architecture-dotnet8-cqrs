using MediatR;
using MyProductApp.Application.DTOs;
using MyProductApp.Application.Interfaces.Repositories;
using MyProductApp.Domain.Entities;

namespace MyProductApp.Application.Features.Products.Commands.CreateProduct;

public class CreateproductHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _repository;

    public CreateproductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price, request.Description);
        await _repository.AddAsync(product, cancellationToken);

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}