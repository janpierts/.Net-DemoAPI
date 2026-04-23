using Demo.Application.demo.Features.Catalog.Commands;
using Demo.Application.demo.ports.In;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.demo.Controller;

[ApiController]
[Route("api/[controller]")]
//[ApiExplorerSettings(GroupName = "Command")]
public class ApiCommandController : ControllerBase
{
    private readonly IProductService _productService;
    public ApiCommandController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateUpdateProductCommand command){
        var validator = new CreateProductCommandValidador();
        var result = await validator.ValidateAsync(command);
        if (!result.IsValid) 
        {
            return BadRequest(result.Errors);
        }
        return Ok(await _productService.Create(command));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]CreateUpdateProductCommand command){
        var validator = new UpdateProductCommandValidador();
        var result = await validator.ValidateAsync(command);
        if (!result.IsValid) 
        {
            return BadRequest(result.Errors);
        }
        return Ok(await _productService.Update(id, command));
    }
}
