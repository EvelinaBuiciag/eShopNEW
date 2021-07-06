using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Producting.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class cartsController : ControllerBase
    {
        private readonly ProductsContext db;

        public cartsController(ProductsContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get() //get all carts
        {
            return Ok(await db.Carts.ToListAsync());
        }

        [HttpGet("{id}")] //Get cart by id
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await db.Carts.FindAsync(id);
            if (cart == null)
                return NotFound();
            return Ok(cart);
        }
        [HttpGet] //Get carts products
        [Route("/api/carts/{cid}/products")]
        public async Task<IActionResult> GetCartProducts(int cid)
        {
            var products = await db.Products.Where(t => t.CartId == cid).ToListAsync();
            if (products == null || products.Count <= 0)
                return NotFound();

            return Ok(products);
        }
       [HttpPut("{id}")] //Edit a cart
        public async Task<IActionResult> UpddateCart(int id, [FromBody] Cart cart)
        {
            if (id != cart.CartId) return BadRequest();

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                if (await db.Carts.FindAsync(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }
        [HttpPost] //Create a cart
        public async Task<IActionResult> PostCart([FromBody] Cart cart)
        {
            db.Carts.Add(cart);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                    new { id = cart.CartId },
                    cart
                );
        }
    }
}