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
    public class MotherboardsController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public MotherboardsController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/Motherboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motherboard>>> GetMotherboards()
        {
            return await _context.Motherboards.ToListAsync();
        }

        // GET: api/Motherboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motherboard>> GetMotherboard(int id)
        {
            var motherboard = await _context.Motherboards.FindAsync(id);

            if (motherboard == null)
            {
                return NotFound();
            }

            return motherboard;
        }

        // PUT: api/Motherboards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotherboard(int id, Motherboard motherboard)
        {
            if (id != motherboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(motherboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotherboardExists(id))
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

        // POST: api/Motherboards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motherboard>> PostMotherboard(Motherboard motherboard)
        {
            _context.Motherboards.Add(motherboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotherboard", new { id = motherboard.Id }, motherboard);
        }

        // DELETE: api/Motherboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotherboard(int id)
        {
            var motherboard = await _context.Motherboards.FindAsync(id);
            if (motherboard == null)
            {
                return NotFound();
            }

            _context.Motherboards.Remove(motherboard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotherboardExists(int id)
        {
            return _context.Motherboards.Any(e => e.Id == id);
        }
    }
}
