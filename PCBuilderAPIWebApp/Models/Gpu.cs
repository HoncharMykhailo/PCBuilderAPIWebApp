namespace PCBuilderAPIWebApp.Models
{
    public class Gpu
    {

        public Gpu()
        {
       //     Motherboards = new List<Motherboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int PowerDemand { get; set; }
        public int Vram { get; set; }
        public float Speed { get; set; }
        public byte[]? ImageData { get; set; }
        public virtual FormFactor? FormFactor { get; set; }
        public virtual GpuSocket? GpuSocket { get; set; }
        public virtual Brand? Brand { get; set; }

        public int FormFactorId { get; set; }
        public int GpuSocketId { get; set; }
        public int BrandId { get; set; }
   //     public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
