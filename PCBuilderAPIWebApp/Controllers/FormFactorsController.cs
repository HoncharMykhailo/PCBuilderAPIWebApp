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
    public class FormFactorsController : ControllerBase
    {
        private readonly PCBuilderAPIContext _context;

        public FormFactorsController(PCBuilderAPIContext context)
        {
            _context = context;
        }

        // GET: api/FormFactors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormFactor>>> GetFormFactors()
        {
            return await _context.FormFactors.ToListAsync();
        }

        // GET: api/FormFactors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormFactor>> GetFormFactor(int id)
        {
            var formFactor = await _context.FormFactors.FindAsync(id);

            if (formFactor == null)
            {
                return NotFound();
            }

            return formFactor;
        }

        // PUT: api/FormFactors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormFactor(int id, FormFactor formFactor)
        {
            if (id != formFactor.Id)
            {
                return BadRequest();
            }

            _context.Entry(formFactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormFactorExists(id))
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

        // POST: api/FormFactors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormFactor>> PostFormFactor(FormFactor formFactor)
        {
            _context.FormFactors.Add(formFactor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormFactor", new { id = formFactor.Id }, formFactor);
        }

        // DELETE: api/FormFactors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormFactor(int id)
        {
            var formFactor = await _context.FormFactors.FindAsync(id);
            if (formFactor == null)
            {
                return NotFound();
            }

            _context.FormFactors.Remove(formFactor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormFactorExists(int id)
        {
            
            return _context.FormFactors.Any(e => e.Id == id);
        }
    }
}
