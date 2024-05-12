using Microsoft.EntityFrameworkCore;


namespace PCBuilderAPIWebApp.Models
{
    public class PCBuilderAPIContext:DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<PowerSupply> PowerSupplies { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<ProcessorSocket> ProcessorSockets { get; set; }
        public virtual DbSet<Gpu> Gpus { get; set; }
        public virtual DbSet<GPUSocket> GPUSockets { get; set; }
        public virtual DbSet<CPUCooler> CPUCoolers { get; set; }
        public virtual DbSet<Ram> Rams { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
        public virtual DbSet<FormFactor> FormFactors { get; set; }

        public PCBuilderAPIContext(DbContextOptions<PCBuilderAPIContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }


       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Case>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Case>()
                .HasOne(m => m.PowerSupply)
                .WithMany()
                .HasForeignKey(m => m.PowerSupplyId);
            modelBuilder.Entity<Case>()
                .HasOne(m => m.FormFactor)
                .WithMany()
                .HasForeignKey(m => m.FormFactorId);
            modelBuilder.Entity<Case>()
                .HasOne(m => m.Motherboard)
                .WithMany()
                .HasForeignKey(m => m.MotherboardId);
            modelBuilder.Entity<Case>().HasKey(b => b.Id);




            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.FormFactor)
                .WithMany()
                .HasForeignKey(m => m.FormFactorId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.ProcessorSocket)
                .WithMany(c => c.Motherboards)
                .HasForeignKey(m => m.ProcessorSocketId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.GPUSocket)
                .WithMany()
                .HasForeignKey(m => m.GPUSocketId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.Processor)
                .WithMany()
                .HasForeignKey(m => m.ProcessorId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.Gpu)
                .WithMany()
                .HasForeignKey(m => m.GpuId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.Ram)
                .WithMany()
                .HasForeignKey(m => m.RamId);
            modelBuilder.Entity<Motherboard>()
                .HasOne(m => m.Memory)
                .WithMany()
                .HasForeignKey(m => m.MemoryId);
            modelBuilder.Entity<Motherboard>().HasKey(b => b.Id);




            modelBuilder.Entity<PowerSupply>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<PowerSupply>().HasKey(b => b.Id);




            modelBuilder.Entity<Processor>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Processor>()
                .HasOne(m => m.ProcessorSocket)
                .WithMany()
                .HasForeignKey(m => m.ProcessorSocketId);
            modelBuilder.Entity<Processor>().HasKey(b => b.Id);




            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.GPUSocket)
                .WithMany()
                .HasForeignKey(m => m.GPUSocketId);
            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.FormFactor)
                .WithMany()
                .HasForeignKey(m => m.FormFactorId);
            modelBuilder.Entity<Gpu>().HasKey(b => b.Id);



            modelBuilder.Entity<CPUCooler>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<CPUCooler>().HasKey(b => b.Id);



            modelBuilder.Entity<Ram>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Ram>().HasKey(b => b.Id);



            modelBuilder.Entity<Memory>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId);
            modelBuilder.Entity<Memory>().HasKey(b => b.Id);



            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            modelBuilder.Entity<FormFactor>().HasKey(b => b.Id);
            modelBuilder.Entity<ProcessorSocket>().HasKey(b => b.Id);
            modelBuilder.Entity<GPUSocket>().HasKey(b => b.Id);

        
        }
        
        
    }
}
