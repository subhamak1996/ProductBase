using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductBase.Data;
using ProductBase.Models.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly ProdectDetailesDBContext _context;

        public RegistrationsController(ProdectDetailesDBContext context)
        {
            _context = context;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regestration>>> GetRegistrations()
        {
            return await _context.Reg.ToListAsync();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regestration>> GetRegistration(Guid id)
        {
            var registration = await _context.Reg.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<ActionResult<Regestration>> PostRegistration(Regestration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            registration.Id = Guid.NewGuid();
            _context.Reg.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistration), new { id = registration.Id }, registration);
        }

        // PUT: api/Registrations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(Guid id, Regestration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // DELETE: api/Registrations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRegistration(Guid id)
        //{
        //    var registration = await _context.Reg.FindAsync(id);
        //    if (registration == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reg.Remove(registration);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool RegistrationExists(Guid id)
        {
            return _context.Reg.Any(e => e.Id == id);
        }
    }
}
