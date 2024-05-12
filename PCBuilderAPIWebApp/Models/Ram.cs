namespace PCBuilderAPIWebApp.Models
{
    public class Ram
    {
        public Ram()
        {
            Motherboards = new List<Motherboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int PowerDemand { get; set; }
        public string Capacity { get; set; }
        public int Speed { get; set; }
        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }
        public virtual ICollection<Motherboard> Motherboards { get; set;}
    }
}
