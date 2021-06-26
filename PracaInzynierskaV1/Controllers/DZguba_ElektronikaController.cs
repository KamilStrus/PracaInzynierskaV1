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
    public class DZguba_ElektronikaController : ControllerBase
    {
        private readonly MyDBContext _context;

        public DZguba_ElektronikaController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/DZguba_Elektronika
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DZguba_Elektronika>>> GetDZguba_Elektronika()
        {
            return await _context.DZguba_Elektronika.ToListAsync();
        }

        // GET: api/DZguba_Elektronika/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DZguba_Elektronika>> GetDZguba_Elektronika(int id)
        {
            var dZguba_Elektronika = await _context.DZguba_Elektronika.FindAsync(id);

            if (dZguba_Elektronika == null)
            {
                return NotFound();
            }

            return dZguba_Elektronika;
        }

        // PUT: api/DZguba_Elektronika/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDZguba_Elektronika(int id, DZguba_Elektronika dZguba_Elektronika)
        {
            if (id != dZguba_Elektronika.id)
            {
                return BadRequest();
            }

            _context.Entry(dZguba_Elektronika).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DZguba_ElektronikaExists(id))
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

        // POST: api/DZguba_Elektronika
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DZguba_Elektronika>> PostDZguba_Elektronika(DZguba_Elektronika dZguba_Elektronika)
        {
            _context.DZguba_Elektronika.Add(dZguba_Elektronika);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDZguba_Elektronika", new { id = dZguba_Elektronika.id }, dZguba_Elektronika);
        }

        // DELETE: api/DZguba_Elektronika/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DZguba_Elektronika>> DeleteDZguba_Elektronika(int id)
        {
            var dZguba_Elektronika = await _context.DZguba_Elektronika.FindAsync(id);
            if (dZguba_Elektronika == null)
            {
                return NotFound();
            }

            _context.DZguba_Elektronika.Remove(dZguba_Elektronika);
            await _context.SaveChangesAsync();

            return dZguba_Elektronika;
        }

        private bool DZguba_ElektronikaExists(int id)
        {
            return _context.DZguba_Elektronika.Any(e => e.id == id);
        }
    }
}
