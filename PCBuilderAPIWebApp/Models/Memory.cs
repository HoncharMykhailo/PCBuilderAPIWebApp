namespace PCBuilderAPIWebApp.Models
{
    public class Memory
    {
        public Memory()
        {
      //      Motherboards = new List<Motherboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public byte[]? ImageData { get; set; }
        public virtual Brand? Brand { get; set; }
        public int BrandId { get; set; }
     //   public virtual ICollection<Motherboard> Motherboards { get; set; }
    }
}
