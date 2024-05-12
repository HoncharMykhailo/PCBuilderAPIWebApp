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
        public string Power { get; set; }
        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }
        public virtual ICollection<Case> Cases { get; set;}
    }
}
