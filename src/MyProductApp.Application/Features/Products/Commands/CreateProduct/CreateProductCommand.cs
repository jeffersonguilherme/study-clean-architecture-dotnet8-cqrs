using MediatR;
using MyProductApp.Application.DTOs;

namespace MyProductApp.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, decimal Price, string Description) : IRequest<ProductResponseDto>;