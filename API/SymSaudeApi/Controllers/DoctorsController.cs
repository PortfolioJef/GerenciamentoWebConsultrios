﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SymSaudeApi.Helpers;
using SymSaudeApi.Models;

namespace SymSaudeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Getdoctors()
        {
            return await _context.doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            try
            {
                _context.doctors.Add(doctor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDoctor", new { id = doctor.id }, doctor);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _context.doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(int id)
        {
            return _context.doctors.Any(e => e.id == id);
        }
    }
}
