namespace PCBuilderAPIWebApp.Models
{

  /* 
  form factors
   
        ATX,
        MicroATX,
        MiniITX,
        EATX,
        MiniTower,
        MidTower,
        FullTower
   */

    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        
        public virtual Motherboard Motherboard { get; set; }
        public virtual PowerSupply PowerSupply { get; set; }
        public virtual FormFactor FormFactor { get; set; }
        public virtual Brand Brand { get; set; }

        public int MotherboardId { get; set; }
        public int PowerSupplyId { get; set; }
        public int FormFactorId { get; set; }
        public int BrandId { get; set; }
    }
}
