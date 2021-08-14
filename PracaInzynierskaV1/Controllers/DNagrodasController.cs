using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracaInzynierskaV1.Models;

namespace PracaInzynierskaV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DNagrodasController : ControllerBase
    {
        private readonly MyDBContext _context;

        public DNagrodasController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/DNagrodas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DNagroda>>> GetDNagroda()
        {
            return await _context.DNagroda.ToListAsync();
        }

        // GET: api/DNagrodas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DNagroda>> GetDNagroda(string id)
        {
            var dNagroda = await _context.DNagroda.FindAsync(id);

            if (dNagroda == null)
            {
                return NotFound();
            }

            return dNagroda;
        }

        // PUT: api/DNagrodas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDNagroda(string id, DNagroda dNagroda)
        {
            dNagroda.id = id;
            

            _context.Entry(dNagroda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNagrodaExists(id))
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

        // POST: api/DNagrodas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DNagroda>> PostDNagroda(DNagroda dNagroda)
        {
            _context.DNagroda.Add(dNagroda);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DNagrodaExists(dNagroda.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDNagroda", new { id = dNagroda.id }, dNagroda);
        }

        // DELETE: api/DNagrodas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DNagroda>> DeleteDNagroda(string id)
        {
            var dNagroda = await _context.DNagroda.FindAsync(id);
            if (dNagroda == null)
            {
                return NotFound();
            }

            _context.DNagroda.Remove(dNagroda);
            await _context.SaveChangesAsync();

            return dNagroda;
        }

        private bool DNagrodaExists(string id)
        {
            return _context.DNagroda.Any(e => e.id == id);
        }
    }
}
