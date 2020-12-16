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
    public class DUsersController : ControllerBase
    {
        private readonly MyDBContext _context;

        public DUsersController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/DUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DUser>>> GetDUser()
        {
            return await _context.DUser.ToListAsync();
        }

        // GET: api/DUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DUser>> GetDUser(string id)
        {
            var dUser = await _context.DUser.FindAsync(id);

            if (dUser == null)
            {
                return NotFound();
            }

            return dUser;
        }

        // PUT: api/DUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDUser(string id, DUser dUser)
        {
            dUser.id = id;
          

            _context.Entry(dUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DUserExists(id))
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

        // POST: api/DUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DUser>> PostDUser(DUser dUser)
        {
            _context.DUser.Add(dUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DUserExists(dUser.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDUser", new { id = dUser.id }, dUser);
        }

        // DELETE: api/DUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DUser>> DeleteDUser(string id)
        {
            var dUser = await _context.DUser.FindAsync(id);
            if (dUser == null)
            {
                return NotFound();
            }

            _context.DUser.Remove(dUser);
            await _context.SaveChangesAsync();

            return dUser;
        }

        private bool DUserExists(string id)
        {
            return _context.DUser.Any(e => e.id == id);
        }
    }
}
