using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Domain;
using ProductBase.Models.Product;
using ProductBase.Server.Repositories;

namespace ProductBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepo _producttyperepo;

        public ProductTypesController(IProductTypeRepo producttyperepo)
        {
            _producttyperepo = producttyperepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> Getproducttype()
        {
            var producttype = _producttyperepo.GetAllAsync().Result;
            return Ok(producttype);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(Guid id)
        {

            var productType = await _producttyperepo.GetByIdAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            return productType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(Guid id, ProductType productType)
        {
            if (id != productType.PTId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _producttyperepo.UpdateAsync(productType);
            }
            catch (Exception)
            {
                if (!await _producttyperepo.ExistsAsync(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProducttype = await _producttyperepo.AddAsync(productType);
            return CreatedAtAction(nameof(Getproducttype), new { id = createdProducttype.PTId }, createdProducttype);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(Guid id)
        {
            var Producttype = await _producttyperepo.GetByIdAsync(id);
            if (Producttype == null)
            {
                return NotFound();
            }

            await _producttyperepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
