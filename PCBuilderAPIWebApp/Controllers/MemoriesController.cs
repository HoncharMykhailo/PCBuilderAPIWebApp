using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilderAPIWebApp.Models;

namespace PCBuilderAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoriesController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public MemoriesController(PCBuilderAPIContext context)
        {
            _context = context;
           
        }

        // GET: api/Memories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Memory>>> GetMemories()
        {
            // return await _context.Memories.ToListAsync();

            return await _context.Memories
               .Include(c => c.Brand)
               .ToListAsync();
        }

        // GET: api/Memories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Memory>> GetMemory(int id)
        {
            // var memory = await _context.Memories.FindAsync(id);

            var memory = await _context.Memories
               .Include(c => c.Brand)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (memory == null)
            {
                return NotFound();
            }

            return memory;
        }

        // PUT: api/Memories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemory(int id, Memory memory)
        {
            if (id != memory.Id)
            {
                return BadRequest();
            }

            var brand = await _context.Brands.FindAsync(memory.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }

            memory.Brand = brand;



            _context.Entry(memory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemoryExists(id))
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

        // POST: api/Memories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Memory>> PostMemory(Memory memory)
        {

            var brand = await _context.Brands.FindAsync(memory.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }

            memory.Brand = brand;



            _context.Memories.Add(memory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemory", new { id = memory.Id }, memory);
        }

        // DELETE: api/Memories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemory(int id)
        {
            var memory = await _context.Memories.FindAsync(id);
            if (memory == null)
            {
                return NotFound();
            }

            _context.Memories.Remove(memory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemoryExists(int id)
        {
            return _context.Memories.Any(e => e.Id == id);
        }
    }
}
