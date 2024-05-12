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
    public class GpusController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public GpusController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/Gpus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gpu>>> GetGpus()
        {
            return await _context.Gpus.ToListAsync();
        }

        // GET: api/Gpus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gpu>> GetGpu(int id)
        {
            var gpu = await _context.Gpus.FindAsync(id);

            if (gpu == null)
            {
                return NotFound();
            }

            return gpu;
        }

        // PUT: api/Gpus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGpu(int id, Gpu gpu)
        {
            if (id != gpu.Id)
            {
                return BadRequest();
            }

            _context.Entry(gpu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpuExists(id))
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

        // POST: api/Gpus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gpu>> PostGpu(Gpu gpu)
        {
            _context.Gpus.Add(gpu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGpu", new { id = gpu.Id }, gpu);
        }

        // DELETE: api/Gpus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGpu(int id)
        {
            var gpu = await _context.Gpus.FindAsync(id);
            if (gpu == null)
            {
                return NotFound();
            }

            _context.Gpus.Remove(gpu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GpuExists(int id)
        {
            return _context.Gpus.Any(e => e.Id == id);
        }
    }
}
