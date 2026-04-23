using Microsoft.AspNetCore.Mvc;

namespace Demo.API.demo.Controller.ApiQueryController;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Query")]
public class ApiQueryController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id){
        return Ok();
    }
}
