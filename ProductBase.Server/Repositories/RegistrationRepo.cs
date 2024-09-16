using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Domain;

namespace ProductBase.Server.Repositories
{
    public class RegistrationRepo:IRegistrationRepo
    {
        private readonly ProdectDetailesDBContext _context;

        public RegistrationRepo(ProdectDetailesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Regestration>> GetAllAsync()
        {
            return await _context.Reg.ToListAsync();
        }

        public async Task<Regestration> GetByIdAsync(Guid id)
        {
            return await _context.Reg.FindAsync(id);
        }

        public async Task<Regestration> AddAsync(Regestration registration)
        {
            registration.Id = Guid.NewGuid();
            _context.Reg.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task UpdateAsync(Regestration registration)
        {
            _context.Entry(registration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var registration = await _context.Reg.FindAsync(id);
            if (registration != null)
            {
                _context.Reg.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Reg.AnyAsync(e => e.Id == id);
        }
    }
}
