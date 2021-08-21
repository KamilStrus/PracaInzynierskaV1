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
    public class DUser_DNagrodaController : ControllerBase
    {
        private readonly MyDBContext _context;

        public DUser_DNagrodaController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/DUser_DNagroda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DUser_DNagroda>>> GetDUser_DNagroda()
        {
            return await _context.DUser_DNagroda.ToListAsync();
        }

        // GET: api/DUser_DNagroda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DUser_DNagroda>> GetDUser_DNagroda(string id)
        {
            var dUser_DNagroda = await _context.DUser_DNagroda.FindAsync(id);

            if (dUser_DNagroda == null)
            {
                return NotFound();
            }

            return dUser_DNagroda;
        }

        // PUT: api/DUser_DNagroda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDUser_DNagroda(string id, DUser_DNagroda dUser_DNagroda)
        {
            if (id != dUser_DNagroda.Id)
            {
                return BadRequest();
            }

            _context.Entry(dUser_DNagroda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DUser_DNagrodaExists(id))
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

        // POST: api/DUser_DNagroda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DUser_DNagroda>> PostDUser_DNagroda(DUser_DNagroda dUser_DNagroda)
        {
            _context.DUser_DNagroda.Add(dUser_DNagroda);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DUser_DNagrodaExists(dUser_DNagroda.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDUser_DNagroda", new { id = dUser_DNagroda.Id }, dUser_DNagroda);
        }

        // DELETE: api/DUser_DNagroda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DUser_DNagroda>> DeleteDUser_DNagroda(string id)
        {
            var dUser_DNagroda = await _context.DUser_DNagroda.FindAsync(id);
            if (dUser_DNagroda == null)
            {
                return NotFound();
            }

            _context.DUser_DNagroda.Remove(dUser_DNagroda);
            await _context.SaveChangesAsync();

            return dUser_DNagroda;
        }

        private bool DUser_DNagrodaExists(string id)
        {
            return _context.DUser_DNagroda.Any(e => e.Id == id);
        }
    }
}
