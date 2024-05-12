namespace PCBuilderAPIWebApp.Models
{
    public class FormFactor
    {
        public FormFactor()
        {
            Cases = new List<Case>();
            Motherboards = new List<Motherboard>();
            Gpus = new List<Gpu>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeCoefficient { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Motherboard> Motherboards { get; set; }
        public virtual ICollection<Gpu> Gpus { get; set; }
    }
}
