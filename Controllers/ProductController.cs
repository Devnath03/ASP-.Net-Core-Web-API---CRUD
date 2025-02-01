using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCRUD.Data;
using ProductCRUD.Models;

namespace ProductCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create: POST /api/ product
        [HttpPost]
        public async Task<ActionResult<Product>>
            CreateProduct([FromBody] Product product)
        {
            _context.Productss.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        }

        // Read: GET /api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>>
            GetProducts()
        {
            return await _context.Productss.ToListAsync();
        }

        // Read: GET/api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Productss.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // Update : PUT/api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Delete : DELETE/api/product/{id}
        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteProduct(int id) 
        { 
            var product = await _context.Productss.FindAsync(id);
            if (product == null)
            {
                return NotFound();

            }

            _context.Productss.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
