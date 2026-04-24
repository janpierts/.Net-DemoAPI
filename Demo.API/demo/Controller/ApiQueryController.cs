using Demo.Application.demo.ports.In;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.demo.Controller;

[ApiController]
[Route("api/[controller]")]
//[ApiExplorerSettings(GroupName = "Query")]
public class ApiQueryController : ControllerBase
{
    private readonly IProductService _productService;
    public ApiQueryController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        if(id <= 0)
        {
            return BadRequest("El ID del producto debe ser mayor que cero.");
        }
        return Ok(await _productService.GetById(id));
    }
}
