namespace PCBuilderAPIWebApp.Models
{
    public class PowerSupply
    {/*
        public PowerSupply() 
        {
            Case = new List<Case>();
        }*/
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Power { get; set; }
        public byte[]? ImageData { get; set; }
        public virtual Brand? Brand { get; set; }

        public int BrandId { get; set; }
    //    public virtual ICollection<Case> Cases { get; set;}
    }
}
