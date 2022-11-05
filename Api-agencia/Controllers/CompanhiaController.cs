using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_agencia.Data;
using Api_agencia.Models;

namespace Api_agencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanhiaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CompanhiaController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Companhia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companhia>>> GetCompanhias()
        {
            return await _context.Companhias.ToListAsync();
        }

        // GET: api/Companhia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companhia>> GetCompanhia(long id)
        {
            var companhia = await _context.Companhias.FindAsync(id);

            if (companhia == null)
            {
                return NotFound();
            }

            return companhia;
        }

        // PUT: api/Companhia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanhia(long id, Companhia companhia)
        {
            if (id != companhia.Id)
            {
                return BadRequest();
            }

            _context.Entry(companhia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanhiaExists(id))
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

        // POST: api/Companhia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Companhia>> PostCompanhia(Companhia companhia)
        {
            _context.Companhias.Add(companhia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanhia", new { id = companhia.Id }, companhia);
        }

        // DELETE: api/Companhia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanhia(long id)
        {
            var companhia = await _context.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }

            _context.Companhias.Remove(companhia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanhiaExists(long id)
        {
            return _context.Companhias.Any(e => e.Id == id);
        }
    }
}
