
using Microsoft.Identity.Client;

namespace PCBuilderAPIWebApp.Models
{

    /*
        ATX,
        MicroATX,
        MiniITX,
        EATX
    */

    public class Motherboard
    {
        public Motherboard()
        {
            Cases = new List<Case>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int PowerDemand { get; set; }
        public int MaxRamCapacity { get; set; }
        public int MaxRamSpeed { get; set; }
        public string Chipset { get; set; }


        public virtual FormFactor FormFactor { get; set; }
        public virtual ProcessorSocket ProcessorSocket { get; set; } 
        public virtual Brand Brand { get; set; }
        public virtual GpuSocket GpuSocket { get; set; } 
        public virtual Processor Processor { get; set; } 
        public virtual Gpu Gpu { get; set; } 
        public virtual Ram Ram { get; set; } 
        public virtual Memory Memory { get; set; } 
        public virtual CPUCooler CPUCooler { get; set; }
       
        public int FormFactorId { get; set; } 
        public int ProcessorSocketId { get; set; } 
        public int BrandId { get; set; } 
        public int GpuSocketId { get; set; } 
        public int? ProcessorId { get; set; } 
        public int? GpuId { get; set; } 
        public int? RamId { get; set; } 
        public int? MemoryId { get; set; } 
        public int? CpuCoolerId { get; set; }

        public virtual ICollection<Case> Cases { get; set; }

    }
}
