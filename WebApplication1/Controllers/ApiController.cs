using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

[ApiController]
public class ApiController
{
    private readonly ApplicationContext _dbContext;

    public ApiController(
        ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("all-categories")]
    public async Task<IActionResult> GetCategories()
    {
        return new JsonResult(
            await _dbContext.Set<Category>()
                .OrderBy(p => p.Name)
                .ToArrayAsync());
    }
    
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts([FromQuery] int? categoryId)
    {
        if (categoryId.HasValue)
        {
            return new JsonResult(
                await _dbContext.Set<Product>()
                    .Where(p => p.CategoryId == categoryId)
                    .OrderBy(p => p.Id)
                    .ToArrayAsync());
        }
        
        return new JsonResult(
            await _dbContext.Set<Product>()
                .OrderBy(p => p.Id)
                .ToArrayAsync());
    }
}