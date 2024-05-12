using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilderAPIWebApp.Models;

namespace PCBuilderAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamsController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public RamsController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ram>>> GetRams()
        {
            return await _context.Rams.ToListAsync();
        }

        // GET: api/Rams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ram>> GetRam(int id)
        {
            var ram = await _context.Rams.FindAsync(id);

            if (ram == null)
            {
                return NotFound();
            }

            return ram;
        }

        // PUT: api/Rams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRam(int id, Ram ram)
        {
            if (id != ram.Id)
            {
                return BadRequest();
            }

            _context.Entry(ram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RamExists(id))
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

        // POST: api/Rams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ram>> PostRam(Ram ram)
        {
            _context.Rams.Add(ram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRam", new { id = ram.Id }, ram);
        }

        // DELETE: api/Rams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRam(int id)
        {
            var ram = await _context.Rams.FindAsync(id);
            if (ram == null)
            {
                return NotFound();
            }

            _context.Rams.Remove(ram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RamExists(int id)
        {
            return _context.Rams.Any(e => e.Id == id);
        }
    }
}
