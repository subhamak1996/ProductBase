using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProductBase.Data;
using ProductBase.Models.Domain;
using ProductBase.Server.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBase.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationRepo _registrationRepo;
        private readonly ProdectDetailesDBContext _context;

        public RegistrationsController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Regestration>>> GetRegistrations()
        {
            var registrations = await _registrationRepo.GetAllAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Regestration>> GetRegistration(Guid id)
        {
            var registration = await _registrationRepo.GetByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        [HttpPost]
        public async Task<ActionResult<Regestration>> PostRegistration(Regestration registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRegistration = await _registrationRepo.AddAsync(registration);
            return CreatedAtAction(nameof(GetRegistration), new { id = createdRegistration.Id }, createdRegistration);
        }

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

            try
            {
                await _registrationRepo.UpdateAsync(registration);
            }
            catch (Exception)
            {
                if (!await _registrationRepo.ExistsAsync(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(Guid id)
        {
            var registration = await _registrationRepo.GetByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            await _registrationRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
