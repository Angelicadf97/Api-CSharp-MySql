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
    public class AeroportoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AeroportoController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Aeroportoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroportos()
        {
            return await _context.Aeroportos.ToListAsync();
        }

        // GET: api/Aeroportoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(long id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(long id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(Aeroporto aeroporto)
        {
            _context.Aeroportos.Add(aeroporto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Id }, aeroporto);
        }

        // DELETE: api/Aeroportoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(long id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroportos.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(long id)
        {
            return _context.Aeroportos.Any(e => e.Id == id);
        }
    }
}
