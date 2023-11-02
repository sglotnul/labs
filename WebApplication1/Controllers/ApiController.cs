using System;
using System.Linq;
using System.Text.Json.Serialization;
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
    
    [HttpPost("order")]
    public async Task<JsonResult> Order([FromBody] OrderForm formData)
    {
        var products = _dbContext.Set<Product>().Where(p => formData.OrderIds.Contains(p.Id)).ToList();
        
        var order = new Order
        {
            CustomerName = formData.Name.Trim(),
            CustomerAddress = string.Join(' ', formData.Country.Trim(), formData.City.Trim(), formData.State.Trim(), formData.Zip.Trim(), formData.Line1.Trim(), formData.Line2.Trim(), formData.Line3.Trim()),
            GiftWrap = formData.GiftWrap,
            Products = products
        };
        
        var entity = _dbContext.Set<Order>().Add(order);

        return new JsonResult(entity.Entity);
    }
}