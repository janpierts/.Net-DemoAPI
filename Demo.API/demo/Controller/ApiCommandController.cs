using Microsoft.AspNetCore.Mvc;

namespace Demo.API.demo.Controller.ApiCommandController;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Command")]
public class ApiCommandController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCommand command){
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateCommand command){
        return Ok();
    }
}
