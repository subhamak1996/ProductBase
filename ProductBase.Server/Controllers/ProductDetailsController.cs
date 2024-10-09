using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Product;
using ProductBase.Server.Repositories;
using ProductBase.Server.ResponseDTO;

namespace ProductBase.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ProdectDetailesDBContext _context;
        private readonly IProductDetailsRepo _productDetailsRepo;

        public ProductDetailsController(ProdectDetailesDBContext context, IProductDetailsRepo productDetailsRepo)
        {
            _context = context;
            _productDetailsRepo= productDetailsRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetailsDTO>>> GetProductDetails()
        {
            var productDetails = await _productDetailsRepo.GetAllAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductDetails(Guid id)
        {
            var productDetails = await _productDetailsRepo.GetByIdAsync(id);           
            return productDetails;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetails(Guid id, ProductDetails productDetails)
        {
            if (id != productDetails.PDId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productDetailsRepo.UpdateAsync(productDetails);
            }
            catch (Exception)
            {
                
            }
            return NoContent();          
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetails>> PostProductDetails(ProductDetails productDetails)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productdetails=_productDetailsRepo.AddAsync(productDetails);  
            return CreatedAtAction(nameof(GetProductDetails), new { id = productdetails.Id}, productdetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails(Guid id)
        {
            var productDetails = await _productDetailsRepo.GetByIdAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }
           await _productDetailsRepo.DeleteAsync(id);
            return NoContent();
        }

        //private bool ProductDetailsExists(Guid id)
        //{
        //    return _context.productdetails.Any(e => e.PDId == id);
        //}
    }
}
