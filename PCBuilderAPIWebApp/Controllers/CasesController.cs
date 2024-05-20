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
    public class CasesController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public CasesController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetCases()
        {
            return await _context.Cases.Include(c => c.Brand).Include(c => c.FormFactor).ToListAsync();
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCase(int id)
        {
            var pcCase = await _context.Cases.Include(c => c.Brand).Include(c => c.FormFactor).FirstOrDefaultAsync(c => c.Id == id);

            if (pcCase == null)
            {
                return NotFound();
            }

            return pcCase;
        }

        // PUT: api/Cases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase(int id, Case pcCase)
        {
            if (id != pcCase.Id)
            {
                return BadRequest();
            }

            var brand = await _context.Brands.FindAsync(pcCase.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            pcCase.Brand = brand;

            var formFactor = await _context.FormFactors.FindAsync(pcCase.FormFactorId);
            if (formFactor == null)
            {
                return NotFound("FormFactor not found");
            }
            pcCase.FormFactor = formFactor;

            _context.Entry(pcCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseExists(id))
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

        // POST: api/Cases
        [HttpPost]
        public async Task<ActionResult<Case>> PostCase(Case pcCase)
        {
            var brand = await _context.Brands.FindAsync(pcCase.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            pcCase.Brand = brand;

            var formFactor = await _context.FormFactors.FindAsync(pcCase.FormFactorId);
            if (formFactor == null)
            {
                return NotFound("FormFactor not found");
            }
            pcCase.FormFactor = formFactor;

            _context.Cases.Add(pcCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCase", new { id = pcCase.Id }, pcCase);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var pcCase = await _context.Cases.FindAsync(id);
            if (pcCase == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(pcCase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
