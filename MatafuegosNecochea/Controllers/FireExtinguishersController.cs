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
    public class FireExtinguishersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FireExtinguishersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FireExtinguishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FireExtinguisher>>> GetFireExtinguisher()
        {
            return await _context.FireExtinguisher.ToListAsync();
        }

        // GET: api/FireExtinguishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FireExtinguisher>> GetFireExtinguisher(int id)
        {
            var fireExtinguisher = await _context.FireExtinguisher.FindAsync(id);

            if (fireExtinguisher == null)
            {
                return NotFound();
            }

            return fireExtinguisher;
        }

        // PUT: api/FireExtinguishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFireExtinguisher(int id, FireExtinguisher fireExtinguisher)
        {
            if (id != fireExtinguisher.Id)
            {
                return BadRequest();
            }

            _context.Entry(fireExtinguisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FireExtinguisherExists(id))
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

        // POST: api/FireExtinguishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FireExtinguisher>> PostFireExtinguisher(FireExtinguisher fireExtinguisher)
        {
            _context.FireExtinguisher.Add(fireExtinguisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFireExtinguisher", new { id = fireExtinguisher.Id }, fireExtinguisher);
        }

        // DELETE: api/FireExtinguishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFireExtinguisher(int id)
        {
            var fireExtinguisher = await _context.FireExtinguisher.FindAsync(id);
            if (fireExtinguisher == null)
            {
                return NotFound();
            }

            _context.FireExtinguisher.Remove(fireExtinguisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FireExtinguisherExists(int id)
        {
            return _context.FireExtinguisher.Any(e => e.Id == id);
        }
    }
}
