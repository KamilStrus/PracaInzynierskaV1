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
    public class DZgubaController : ControllerBase
    {
        private readonly MyDBContext _context;
        public IConfiguration Configuration { get; }
        public DZgubaController(IConfiguration configuration, MyDBContext context)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: api/DZguba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DZguba>>> GetDZguby()
        {

            return await _context.DZguby.ToListAsync();
        }

        // GET: api/DZguba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DZguba>> GetDZguba(int id)
        {
            var dZguba = await _context.DZguby.FindAsync(id);

            if (dZguba == null)
            {
                return NotFound();
            }

            return dZguba;
        }

        // PUT: api/DZguba/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDZguba(int id, DZguba dZguba)
        {
            dZguba.id = id;
            dZguba.UpdatedDate = DateTime.Now;

            _context.Entry(dZguba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DZgubaExists(id))
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

        // POST: api/DZguba
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DZguba>> PostDZguba(DZguba dZguba)
        {

            dZguba.CreatedDate = DateTime.Now;
            dZguba.UpdatedDate = DateTime.Now;

            _context.Entry(dZguba.DUser).State = EntityState.Unchanged;
            _context.DZguby.Add(dZguba);

            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            using (var command = new SqlCommand("UserPointsAdd", conn)
            {
                CommandType = CommandType.StoredProcedure
            
        })
            {
                command.Parameters.Add("@IdUser", SqlDbType.NVarChar);
                command.Parameters["@IdUser"].Value = dZguba.DUser.id;
                conn.Open();
                int rowAffected = command.ExecuteNonQuery();
                conn.Close();
            }

 

                await _context.SaveChangesAsync();

            return CreatedAtAction("GetDZguba", new { id = dZguba.id }, dZguba);
        }

        // DELETE: api/DZguba/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DZguba>> DeleteDZguba(int id)
        {
            var dZguba = await _context.DZguby.FindAsync(id);
            if (dZguba == null)
            {
                return NotFound();
            }

            _context.DZguby.Remove(dZguba);
            await _context.SaveChangesAsync();

            return dZguba;
        }

        private bool DZgubaExists(int id)
        {
            return _context.DZguby.Any(e => e.id == id);
        }
    }
}
