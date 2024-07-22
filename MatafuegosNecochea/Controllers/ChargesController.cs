using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatafuegosNecochea.Context;
using MatafuegosNecochea.Models.FireE;

namespace MatafuegosNecochea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChargesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Charges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charge>>> GetCharge()
        {
            return await _context.Charge.ToListAsync();
        }

        // GET: api/Charges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charge>> GetCharge(int id)
        {
            var charge = await _context.Charge.FindAsync(id);

            if (charge == null)
            {
                return NotFound();
            }

            return charge;
        }

        // PUT: api/Charges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharge(int id, Charge charge)
        {
            if (id != charge.Id)
            {
                return BadRequest();
            }

            _context.Entry(charge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChargeExists(id))
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

        // POST: api/Charges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Charge>> PostCharge(Charge charge)
        {
            _context.Charge.Add(charge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharge", new { id = charge.Id }, charge);
        }

        // DELETE: api/Charges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharge(int id)
        {
            var charge = await _context.Charge.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }

            _context.Charge.Remove(charge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChargeExists(int id)
        {
            return _context.Charge.Any(e => e.Id == id);
        }
    }
}
