﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracaInzynierskaV1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PracaInzynierskaV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DZguba_ZwierzeController : ControllerBase
    {
        private readonly MyDBContext _context;
        public IConfiguration Configuration { get; }
        public DZguba_ZwierzeController(IConfiguration configuration, MyDBContext context)
        {
            _context = context;
            Configuration = configuration;
        }
        // GET: api/DZguba_Zwierze
        // GET: api/DZguba_Zwierze
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DZguba_Zwierze>>> GetDZguba_Zwierze()
        {
            return await _context.DZguba_Zwierze.ToListAsync();
        }

        // GET: api/DZguba_Zwierze/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DZguba_Zwierze>> GetDZguba_Zwierze(int id)
        {
            var dZguba_Zwierze = await _context.DZguba_Zwierze.FindAsync(id);

            if (dZguba_Zwierze == null)
            {
                return NotFound();
            }
            return dZguba_Zwierze;
        }

        // PUT: api/DZguba_Zwierze/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDZguba_Zwierze(int id, DZguba_Zwierze dZguba_Zwierze)
        {
            dZguba_Zwierze.id = id;
            dZguba_Zwierze.UpdatedDate = DateTime.Now;

            _context.Entry(dZguba_Zwierze).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DZguba_ZwierzeExists(id))
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

        // POST: api/DZguba_Zwierze
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DZguba_Zwierze>> PostDZguba_Zwierze(DZguba_Zwierze dZguba_Zwierze)
        {


            dZguba_Zwierze.CreatedDate = DateTime.Now;
            dZguba_Zwierze.UpdatedDate = DateTime.Now;

            _context.Entry(dZguba_Zwierze.DUser).State = EntityState.Unchanged;
            _context.DZguba_Zwierze.Add(dZguba_Zwierze);

            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            using (var command = new SqlCommand("UserPointsAdd", conn)
            {
                CommandType = CommandType.StoredProcedure

            })
            {
                command.Parameters.Add("@IdUser", SqlDbType.NVarChar);
                command.Parameters["@IdUser"].Value = dZguba_Zwierze.DUser.id;
                conn.Open();
                int rowAffected = command.ExecuteNonQuery();
                conn.Close();
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDZguba_Zwierze", new { id = dZguba_Zwierze.id }, dZguba_Zwierze);
        }

        // DELETE: api/DZguba_Zwierze/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DZguba_Zwierze>> DeleteDZguba_Zwierze(int id)
        {
            var dZguba_Zwierze = await _context.DZguba_Zwierze.FindAsync(id);
            if (dZguba_Zwierze == null)
            {
                return NotFound();
            }

            _context.DZguba_Zwierze.Remove(dZguba_Zwierze);
            await _context.SaveChangesAsync();

            return dZguba_Zwierze;
        }

        private bool DZguba_ZwierzeExists(int id)
        {
            return _context.DZguba_Zwierze.Any(e => e.id == id);
        }
    }
}
