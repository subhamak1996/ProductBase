using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Product;
using ProductBase.Server.ResponseDTO;

namespace ProductBase.Server.Repositories
{
    public class ProductDetailsRepo : IProductDetailsRepo
    {
        private readonly ProdectDetailesDBContext _Context;
        public ProductDetailsRepo(ProdectDetailesDBContext Context)
        {
            _Context = Context; 
        }
        public async Task<ProductDetails> AddAsync(ProductDetails productdetails)
        {
            productdetails.PDId = Guid.NewGuid();
            _Context.productdetails.Add(productdetails);
            await _Context.SaveChangesAsync();
            return productdetails;
        }

        public async Task DeleteAsync(Guid id)
        {
            var productdetails = await _Context.productdetails.FindAsync(id);
            if(productdetails!=null)
            {
                _Context.productdetails.Remove(productdetails);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDetailsDTO>> GetAllAsync()
        {
            var productDetails = from pd in _Context.productdetails
                                 join pt in _Context.producttype on pd.PTId equals pt.PTId.ToString()
                                 select new ProductDetailsDTO
                                 {
                                     ProductTypeName = pt.ProductTypeName,
                                     ProductName = pd.ProductNameName,
                                     ProductDescription = pd.ProductDescription
                                 };
            return await productDetails.ToListAsync();
        }

        public async Task<ProductDetails> GetByIdAsync(Guid id)
        {
            return await _Context.productdetails.FindAsync(id);
        }

        public async Task UpdateAsync(ProductDetails productdetails)
        {
           _Context.Entry(productdetails).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
