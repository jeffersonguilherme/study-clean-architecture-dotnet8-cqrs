using MediatR;
using MyProductApp.Application.DTOs;

namespace MyProductApp.Application.Features.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductResponseDto?>;