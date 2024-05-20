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
            return await _context.Motherboards
                .Include(c => c.Brand)
                .Include(c => c.FormFactor)
                .Include(c => c.ProcessorSocket)
                .Include(c => c.GpuSocket)
                .ToListAsync();

        }

        // GET: api/Motherboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motherboard>> GetMotherboard(int id)
        {
            //var motherboard = await _context.Motherboards.FindAsync(id);
            var motherboard = await _context.Motherboards
                .Include(c => c.Brand)
                .Include(c => c.FormFactor)
                .Include(c => c.ProcessorSocket)
                .Include(c => c.GpuSocket)
                .FirstOrDefaultAsync(c => c.Id == id);

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


            var brand = await _context.Brands.FindAsync(motherboard.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Brand = brand;


            var formfactor = await _context.FormFactors.FindAsync(motherboard.FormFactorId);
            if (formfactor == null)
            {
                return NotFound("FormFactor not found");
            }
            motherboard.FormFactor = formfactor;


            var gpuSocket = await _context.GPUSockets.FindAsync(motherboard.GpuSocketId);
            if (gpuSocket == null)
            {
                return NotFound("GpuSocket not found");
            }
            motherboard.GpuSocket = gpuSocket;


            var processorSocket = await _context.ProcessorSockets.FindAsync(motherboard.ProcessorSocketId);
            if (processorSocket == null)
            {
                return NotFound("ProcessorSocket not found");
            }
            motherboard.ProcessorSocket = processorSocket;

            /*
            var gpu = await _context.Gpus.FindAsync(motherboard.GpuId);
            if (gpu == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Gpu = gpu;


            var processor = await _context.Processors.FindAsync(motherboard.ProcessorId);
            if (processor == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Processor = processor;


            var ram = await _context.Rams.FindAsync(motherboard.RamId);
            if (ram == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Ram = ram;


            var memory = await _context.Memories.FindAsync(motherboard.MemoryId);
            if (memory == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Memory = memory;


            var cpuCooler = await _context.CPUCoolers.FindAsync(motherboard.CpuCoolerId);
            if (cpuCooler == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.CPUCooler = cpuCooler;
            */


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

           

            var brand = await _context.Brands.FindAsync(motherboard.BrandId);
            if (brand == null)
            {
                return NotFound("Brand not found");
            }
            motherboard.Brand = brand;


            var formfactor = await _context.FormFactors.FindAsync(motherboard.FormFactorId);
            if (formfactor == null)
            {
                return NotFound("FormFactor not found");
            }
            motherboard.FormFactor = formfactor;


            var gpuSocket = await _context.GPUSockets.FindAsync(motherboard.GpuSocketId);
            if (gpuSocket == null)
            {
                return NotFound("GpuSocket not found");
            }
            motherboard.GpuSocket = gpuSocket;


            var processorSocket = await _context.ProcessorSockets.FindAsync(motherboard.ProcessorSocketId);
            if (processorSocket == null)
            {
                return NotFound("ProcessorSocket not found");
            }
            motherboard.ProcessorSocket = processorSocket;

            /*
            var gpu = await _context.Gpus.FindAsync(motherboard.GpuId);
            if (gpu == null)
            {
                return NotFound("Gpu not found");
            }
            motherboard.Gpu = gpu;


            var processor = await _context.Processors.FindAsync(motherboard.ProcessorId);
            if (processor == null)
            {
                return NotFound("Processor not found");
            }
            motherboard.Processor = processor;


            var ram = await _context.Rams.FindAsync(motherboard.RamId);
            if (ram == null)
            {
                return NotFound("Ram not found");
            }
            motherboard.Ram = ram;


            var memory = await _context.Memories.FindAsync(motherboard.MemoryId);
            if (memory == null)
            {
                return NotFound("Memory not found");
            }
            motherboard.Memory = memory;


            var cpuCooler = await _context.CPUCoolers.FindAsync(motherboard.CpuCoolerId);
            if (cpuCooler == null)
            {
                return NotFound("CPUCooler not found");
            }
            motherboard.CPUCooler = cpuCooler;


            */



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
