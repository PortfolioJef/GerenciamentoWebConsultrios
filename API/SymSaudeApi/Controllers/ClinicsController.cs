using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SymSaudeApi.Helpers;
using SymSaudeApi.Models;

namespace SymSaudeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly DataContext _context;

        public ClinicsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Clinics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> Getclinics()
        {
            return await _context.clinics.ToListAsync();
        }

        // GET: api/Clinics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetClinic(int id)
        {
            var clinic = await _context.clinics.FindAsync(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        // PUT: api/Clinics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinic(int id, Clinic clinic)
        {
            if (id != clinic.Id)
            {
                return BadRequest();
            }

            _context.Entry(clinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicExists(id))
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

        // POST: api/Clinics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
        {
            _context.clinics.Add(clinic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClinic", new { id = clinic.Id }, clinic);
        }

        // DELETE: api/Clinics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clinic>> DeleteClinic(int id)
        {
            var clinic = await _context.clinics.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }

            _context.clinics.Remove(clinic);
            await _context.SaveChangesAsync();

            return clinic;
        }

        private bool ClinicExists(int id)
        {
            return _context.clinics.Any(e => e.Id == id);
        }
    }
}
