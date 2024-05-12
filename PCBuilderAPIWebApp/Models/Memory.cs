namespace PCBuilderAPIWebApp.Models
{
    public class Memory
    {
        public Memory()
        {
            Motherbords = new List<Motherboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Capacity { get; set; }
        public string Type { get; set; }
        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }
        public virtual ICollection<Motherboard> Motherbords { get; set; }
    }
}
