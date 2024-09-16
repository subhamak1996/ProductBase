using ProductBase.Models.Domain;

namespace ProductBase.Server.Repositories
{
    public interface IRegistrationRepo
    {
        Task<IEnumerable<Regestration>> GetAllAsync();
        Task<Regestration> GetByIdAsync(Guid id);
        Task<Regestration> AddAsync(Regestration registration);
        Task UpdateAsync(Regestration registration);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
