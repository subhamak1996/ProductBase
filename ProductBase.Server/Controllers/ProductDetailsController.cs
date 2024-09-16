using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Product;

namespace ProductBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ProdectDetailesDBContext _context;

        public ProductDetailsController(ProdectDetailesDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> Getproductdetails()
        {
            return await _context.productdetails.ToListAsync();
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductDetails(Guid id)
        {
            var productDetails = await _context.productdetails.FindAsync(id);

            if (productDetails == null)
            {
                return NotFound();
            }

            return productDetails;
        }

        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetails(Guid id, ProductDetails productDetails)
        {
            if (id != productDetails.PDId)
            {
                return BadRequest();
            }

            _context.Entry(productDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDetails>> PostProductDetails(ProductDetails productDetails)
        {
            _context.productdetails.Add(productDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetails", new { id = productDetails.PDId }, productDetails);
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails(Guid id)
        {
            var productDetails = await _context.productdetails.FindAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            _context.productdetails.Remove(productDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductDetailsExists(Guid id)
        {
            return _context.productdetails.Any(e => e.PDId == id);
        }
    }
}
