namespace PCBuilderAPIWebApp.Models
{
    public class Processor
    {

        public Processor()
        {
      //      Motherboards = new List<Motherboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int PowerDemand { get; set; }
        public float Speed { get; set; }
        public int Ncores { get; set; }
        public int MaxRAMCapacity { get; set; }
        public byte[]? ImageData { get; set; }


        public virtual ProcessorSocket? ProcessorSocket { get; set; }
        public virtual Brand? Brand { get; set; }


        public int ProcessorSocketId { get; set; }
        public int BrandId { get; set; }


     //   public virtual ICollection<Motherboard> Motherboards { get; set; }



    }
}
