using Microsoft.AspNetCore.Mvc;

namespace BookHub.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Route("/test")]
    public async Task<IActionResult> Fetch()
    {
        return Ok();
    }
}