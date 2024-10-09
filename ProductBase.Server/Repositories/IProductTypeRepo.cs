using ProductBase.Models.Domain;
using ProductBase.Models.Product;

namespace ProductBase.Server.Repositories
{
    public interface IProductTypeRepo
    {
        Task<IEnumerable<ProductType>> GetAllAsync();
        Task<ProductType> GetByIdAsync(Guid id);
        Task<ProductType> AddAsync(ProductType productType);
        Task UpdateAsync(ProductType registration);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
