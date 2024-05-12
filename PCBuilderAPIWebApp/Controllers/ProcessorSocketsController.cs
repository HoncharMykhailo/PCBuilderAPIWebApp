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
    public class ProcessorSocketsController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public ProcessorSocketsController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProcessorSockets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessorSocket>>> GetProcessorSockets()
        {
            return await _context.ProcessorSockets.ToListAsync();
        }

        // GET: api/ProcessorSockets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessorSocket>> GetProcessorSocket(int id)
        {
            var processorSocket = await _context.ProcessorSockets.FindAsync(id);

            if (processorSocket == null)
            {
                return NotFound();
            }

            return processorSocket;
        }

        // PUT: api/ProcessorSockets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessorSocket(int id, ProcessorSocket processorSocket)
        {
            if (id != processorSocket.Id)
            {
                return BadRequest();
            }

            _context.Entry(processorSocket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessorSocketExists(id))
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

        // POST: api/ProcessorSockets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProcessorSocket>> PostProcessorSocket(ProcessorSocket processorSocket)
        {
            _context.ProcessorSockets.Add(processorSocket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessorSocket", new { id = processorSocket.Id }, processorSocket);
        }

        // DELETE: api/ProcessorSockets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessorSocket(int id)
        {
            var processorSocket = await _context.ProcessorSockets.FindAsync(id);
            if (processorSocket == null)
            {
                return NotFound();
            }

            _context.ProcessorSockets.Remove(processorSocket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessorSocketExists(int id)
        {
            return _context.ProcessorSockets.Any(e => e.Id == id);
        }
    }
}
