using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Domain;
using ProductBase.Models.Product;

namespace ProductBase.Server.Repositories
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private readonly ProdectDetailesDBContext _context;
        public ProductTypeRepo( ProdectDetailesDBContext context)
        {
            _context = context;
        }
        public async Task<ProductType> AddAsync(ProductType productType)
        {
            productType.PTId = Guid.NewGuid();
            _context.producttype.Add(productType);
            await _context.SaveChangesAsync();
            return productType;
        }

        public async Task DeleteAsync(Guid id)
        {
            var producttype = await _context.producttype.FindAsync(id);
            if (producttype != null)
            {
                _context.producttype.Remove(producttype);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.producttype.AnyAsync(e => e.PTId == id);
        }

        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _context.producttype.ToListAsync();
        }

        public async Task<ProductType> GetByIdAsync(Guid id)
        {
            return await _context.producttype.FindAsync(id);
        }

        public async Task UpdateAsync(ProductType productType)
        {           
            _context.Entry(productType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
