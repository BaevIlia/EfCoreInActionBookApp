using EfCoreInActionBookApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreInActionBookApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MockController : Controller
{
    private readonly BookAppDbContext _bookAppDbContext;

    public MockController(BookAppDbContext bookAppDbContext)
    {
        _bookAppDbContext = bookAppDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookData() 
    {
        

        return Ok();
    }
}
