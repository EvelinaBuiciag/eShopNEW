using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using WebAPI.Filters;

namespace Producting.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    //[APIKeyAuthFilter]
    public class productsController : ControllerBase
    {
        private readonly ProductsContext db;

        public productsController(ProductsContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get() //get all products
        {
            return Ok(await db.Products.ToListAsync());
        }

        [HttpGet("{id}")] //get product by id
        public async Task<IActionResult> GetById(int id)
        {
            var product = await db .Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{id}")] //Edit product
        public async Task<IActionResult>  Put(int id, [FromBody] Product product)
        {
            if (id != product.ProductId) return BadRequest();

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                if (await db.Products.FindAsync(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }
    }
}
