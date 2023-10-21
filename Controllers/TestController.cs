using BookHub.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHub.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly BookHubDbContext _dBContext;
    
    public TestController(BookHubDbContext dBContext)
    {
        _dBContext = dBContext;
    }
    
    [HttpGet]
    [Route("/test")]
    public async Task<IActionResult> Fetch()
    {
        var users = await _dBContext.Users.ToListAsync();
        
        return Ok(users.Select(a => new
        {
            UserId = a.Id,
            UserUsername = a.Username,
            UserDateOfCreation = a.CreatedAt,
        }));
    }
}