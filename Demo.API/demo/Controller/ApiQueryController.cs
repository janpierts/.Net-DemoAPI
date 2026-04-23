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
    public async Task<IActionResult> GetById(Guid id){
        return Ok(await _productService.GetById(id));
    }
}
