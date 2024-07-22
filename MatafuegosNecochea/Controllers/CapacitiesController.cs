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
    public class CapacitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CapacitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Capacities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacity>>> GetCapacity()
        {
            return await _context.Capacity.ToListAsync();
        }

        // GET: api/Capacities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacity>> GetCapacity(int id)
        {
            var capacity = await _context.Capacity.FindAsync(id);

            if (capacity == null)
            {
                return NotFound();
            }

            return capacity;
        }

        // PUT: api/Capacities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapacity(int id, Capacity capacity)
        {
            if (id != capacity.Id)
            {
                return BadRequest();
            }

            _context.Entry(capacity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapacityExists(id))
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

        // POST: api/Capacities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Capacity>> PostCapacity(Capacity capacity)
        {
            _context.Capacity.Add(capacity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapacity", new { id = capacity.Id }, capacity);
        }

        // DELETE: api/Capacities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCapacity(int id)
        {
            var capacity = await _context.Capacity.FindAsync(id);
            if (capacity == null)
            {
                return NotFound();
            }

            _context.Capacity.Remove(capacity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CapacityExists(int id)
        {
            return _context.Capacity.Any(e => e.Id == id);
        }
    }
}
