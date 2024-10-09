using ProductBase.Models.Product;
using ProductBase.Server.ResponseDTO;

namespace ProductBase.Server.Repositories
{
    public interface IProductDetailsRepo
    {
        Task<IEnumerable<ProductDetailsDTO>> GetAllAsync();
        Task<ProductDetails> GetByIdAsync(Guid id);
        Task<ProductDetails> AddAsync(ProductDetails productdetails);
        Task UpdateAsync(ProductDetails productdetails);
        Task DeleteAsync(Guid id);
    }
}
