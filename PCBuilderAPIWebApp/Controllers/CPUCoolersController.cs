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
    public class CPUCoolersController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public CPUCoolersController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/CPUCoolers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPUCooler>>> GetCPUCoolers()
        {
            //  return await _context.CPUCoolers.ToListAsync();

            return await _context.CPUCoolers
                .Include(c => c.Brand)
                .ToListAsync();
        }

        // GET: api/CPUCoolers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CPUCooler>> GetCPUCooler(int id)
        {
            // var cPUCooler = await _context.CPUCoolers.FindAsync(id);

            var cPUCooler = await _context.CPUCoolers
               .Include(c => c.Brand)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (cPUCooler == null)
            {
                return NotFound();
            }

            return cPUCooler;
        }

        // PUT: api/CPUCoolers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCPUCooler(int id, CPUCooler cPUCooler)
        {
            if (id != cPUCooler.Id)
            {
                return BadRequest();
            }


            var brand = await _context.Brands.FindAsync(cPUCooler.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }

            cPUCooler.Brand = brand;



            _context.Entry(cPUCooler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPUCoolerExists(id))
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

        // POST: api/CPUCoolers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CPUCooler>> PostCPUCooler(CPUCooler cPUCooler)
        {
            var brand = await _context.Brands.FindAsync(cPUCooler.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }

            cPUCooler.Brand = brand;

            _context.CPUCoolers.Add(cPUCooler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCPUCooler", new { id = cPUCooler.Id }, cPUCooler);
        }

        // DELETE: api/CPUCoolers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCPUCooler(int id)
        {
            var cPUCooler = await _context.CPUCoolers.FindAsync(id);
            if (cPUCooler == null)
            {
                return NotFound();
            }

            _context.CPUCoolers.Remove(cPUCooler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CPUCoolerExists(int id)
        {
            return _context.CPUCoolers.Any(e => e.Id == id);
        }
    }
}
