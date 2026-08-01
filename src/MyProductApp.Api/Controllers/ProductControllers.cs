using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductApp.Application.Features.Products.Commands.CreateProduct;
using MyProductApp.Application.Features.Queries.GetProductById;

namespace MyProductApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand cmd)
    {
        var dto = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(Get), new {id = dto.Id}, dto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var dto = await _mediator.Send(new GetProductByIdQuery(id));
        if(dto== null) return NotFound();

        return Ok(dto);
    }
}