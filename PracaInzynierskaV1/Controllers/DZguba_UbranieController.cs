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
    public class DZguba_UbranieController : ControllerBase
    {
        private readonly MyDBContext _context;

        public DZguba_UbranieController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/DZguba_Ubranie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DZguba_Ubranie>>> GetDZguba_Ubranie()
        {
            return await _context.DZguba_Ubranie.ToListAsync();
        }

        // GET: api/DZguba_Ubranie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DZguba_Ubranie>> GetDZguba_Ubranie(int id)
        {
            var dZguba_Ubranie = await _context.DZguba_Ubranie.FindAsync(id);

            if (dZguba_Ubranie == null)
            {
                return NotFound();
            }

            return dZguba_Ubranie;
        }

        // PUT: api/DZguba_Ubranie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDZguba_Ubranie(int id, DZguba_Ubranie dZguba_Ubranie)
        {
            dZguba_Ubranie.id = id;
         

            _context.Entry(dZguba_Ubranie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DZguba_UbranieExists(id))
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

        // POST: api/DZguba_Ubranie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DZguba_Ubranie>> PostDZguba_Ubranie(DZguba_Ubranie dZguba_Ubranie)
        {
            _context.Entry(dZguba_Ubranie.DUser).State = EntityState.Unchanged;
            _context.DZguba_Ubranie.Add(dZguba_Ubranie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDZguba_Ubranie", new { id = dZguba_Ubranie.id }, dZguba_Ubranie);
        }

        // DELETE: api/DZguba_Ubranie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DZguba_Ubranie>> DeleteDZguba_Ubranie(int id)
        {
            var dZguba_Ubranie = await _context.DZguba_Ubranie.FindAsync(id);
            if (dZguba_Ubranie == null)
            {
                return NotFound();
            }

            _context.DZguba_Ubranie.Remove(dZguba_Ubranie);
            await _context.SaveChangesAsync();

            return dZguba_Ubranie;
        }

        private bool DZguba_UbranieExists(int id)
        {
            return _context.DZguba_Ubranie.Any(e => e.id == id);
        }
    }
}
