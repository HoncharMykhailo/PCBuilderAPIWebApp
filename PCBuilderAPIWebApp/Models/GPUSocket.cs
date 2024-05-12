namespace PCBuilderAPIWebApp.Models
{
    public class GpuSocket
    {
        public GpuSocket()
        {
            Motherboards = new List<Motherboard>();
            Gpus = new List<Gpu>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Motherboard> Motherboards { get; set; }
        public virtual ICollection<Gpu> Gpus { get; set; }
    }
}
