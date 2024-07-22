using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatafuegosNecochea.Context;
using MatafuegosNecochea.Models.Clients;

namespace MatafuegosNecochea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IvasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IvasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ivas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iva>>> GetIva()
        {
            return await _context.Iva.ToListAsync();
        }

        // GET: api/Ivas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iva>> GetIva(int id)
        {
            var iva = await _context.Iva.FindAsync(id);

            if (iva == null)
            {
                return NotFound();
            }

            return iva;
        }

        // PUT: api/Ivas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIva(int id, Iva iva)
        {
            if (id != iva.Id)
            {
                return BadRequest();
            }

            _context.Entry(iva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IvaExists(id))
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

        // POST: api/Ivas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Iva>> PostIva(Iva iva)
        {
            _context.Iva.Add(iva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIva", new { id = iva.Id }, iva);
        }

        // DELETE: api/Ivas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIva(int id)
        {
            var iva = await _context.Iva.FindAsync(id);
            if (iva == null)
            {
                return NotFound();
            }

            _context.Iva.Remove(iva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IvaExists(int id)
        {
            return _context.Iva.Any(e => e.Id == id);
        }
    }
}
