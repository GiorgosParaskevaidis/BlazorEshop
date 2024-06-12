using BlazorEshop.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEshop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BlazoreshopDbContex _context;

        public ProductController(BlazoreshopDbContex context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
