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

        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gpu>>> GetGpus()
        {
            return await _context.Gpus
                .Include(c => c.Brand)
                .Include(c => c.FormFactor)
                .Include(c => c.GpuSocket)
                .ToListAsync();
        }*/


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gpu>>> GetGpus()
        {
            var gpus = await _context.Gpus
                .Include(c => c.Brand)
                .Include(c => c.FormFactor)
                .Include(c => c.GpuSocket)
                .ToListAsync();
            return Ok(gpus); // Ensure it returns an array
        }



        // GET: api/Gpus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gpu>> GetGpu(int id)
        {
            var gpu = await _context.Gpus
                .Include(c => c.Brand)
                .Include(c => c.FormFactor)
                .Include(c => c.GpuSocket)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (gpu == null)
            {
                return NotFound();
            }

            return gpu;
        }

        // PUT: api/Gpus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGpu(int id, Gpu gpu)
        {
            if (id != gpu.Id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _context.Brands.FindAsync(gpu.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            gpu.Brand = brand;

            var formFactor = await _context.FormFactors.FindAsync(gpu.FormFactorId);
            if (formFactor == null)
            {
                return NotFound("FormFactor not found");
            }
            gpu.FormFactor = formFactor;

            var gpuSocket = await _context.GPUSockets.FindAsync(gpu.GpuSocketId);
            if (gpuSocket == null)
            {
                return NotFound("GpuSocket not found");
            }
            gpu.GpuSocket = gpuSocket;

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
        [HttpPost]
        public async Task<ActionResult<Gpu>> PostGpu(Gpu gpu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _context.Brands.FindAsync(gpu.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            gpu.Brand = brand;

            var formFactor = await _context.FormFactors.FindAsync(gpu.FormFactorId);
            if (formFactor == null)
            {
                return NotFound("FormFactor not found");
            }
            gpu.FormFactor = formFactor;

            var gpuSocket = await _context.GPUSockets.FindAsync(gpu.GpuSocketId);
            if (gpuSocket == null)
            {
                return NotFound("GpuSocket not found");
            }
            gpu.GpuSocket = gpuSocket;

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
