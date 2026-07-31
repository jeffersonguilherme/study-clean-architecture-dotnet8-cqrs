using MediatR;
using MyProductApp.Application.DTOs;

namespace MyProductApp.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description) : IRequest<ProductResponseDto>;