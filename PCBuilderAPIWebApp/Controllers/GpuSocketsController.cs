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
    public class GpuSocketsController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public GpuSocketsController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/GpuSockets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GpuSocket>>> GetGPUSockets()
        {
            return await _context.GPUSockets.ToListAsync();
        }

        // GET: api/GpuSockets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GpuSocket>> GetGpuSocket(int id)
        {
            var gpuSocket = await _context.GPUSockets.FindAsync(id);

            if (gpuSocket == null)
            {
                return NotFound();
            }

            return gpuSocket;
        }

        // PUT: api/GpuSockets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGpuSocket(int id, GpuSocket gpuSocket)
        {
            if (id != gpuSocket.Id)
            {
                return BadRequest();
            }

            _context.Entry(gpuSocket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpuSocketExists(id))
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

        // POST: api/GpuSockets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GpuSocket>> PostGpuSocket(GpuSocket gpuSocket)
        {
            _context.GPUSockets.Add(gpuSocket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGpuSocket", new { id = gpuSocket.Id }, gpuSocket);
        }

        // DELETE: api/GpuSockets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGpuSocket(int id)
        {
            var gpuSocket = await _context.GPUSockets.FindAsync(id);
            if (gpuSocket == null)
            {
                return NotFound();
            }

            _context.GPUSockets.Remove(gpuSocket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GpuSocketExists(int id)
        {
            return _context.GPUSockets.Any(e => e.Id == id);
        }
    }
}
