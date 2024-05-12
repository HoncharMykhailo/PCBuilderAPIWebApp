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
        public virtual DbSet<GpuSocket> GPUSockets { get; set; }
        public virtual DbSet<CPUCooler> CPUCoolers { get; set; }
        public virtual DbSet<Ram> Rams { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
        public virtual DbSet<FormFactor> FormFactors { get; set; }

        public PCBuilderAPIContext(DbContextOptions<PCBuilderAPIContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }




        /*
         
 protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.ToTable("Cargo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contain)
                .HasMaxLength(50)
                .HasColumnName("contain");
            entity.Property(e => e.Volume).HasColumnName("volume");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Client).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Client");

            entity.HasOne(d => d.Station).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Station");

            entity.HasOne(d => d.Truck).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.TruckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Truck");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Delivery");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");

            entity.HasOne(d => d.Truck).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.TruckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_Driver");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.ToTable("Station");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.ToTable("Truck");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }
         
         */






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*

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
                .HasOne(m => m.GpuSocket)
                .WithMany()
                .HasForeignKey(m => m.GpuSocketId);
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
            modelBuilder.Entity<GpuSocket>().HasKey(b => b.Id);
            */


            /*
            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Case");
                entity.HasOne(d => d.Brand).WithMany()
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Brand");
                entity.HasOne(d => d.PowerSupply).WithMany()
                    .HasForeignKey(d => d.PowerSupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_PowerSupply");
                entity.HasOne(d => d.Motherboard).WithMany()
                    .HasForeignKey(d => d.MotherboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Motherboard");
            });


            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Brand");
                entity.HasOne(m => m.FormFactor)
                    .WithMany()
                    .HasForeignKey(m => m.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_FormFactor");
                entity.HasOne(m => m.ProcessorSocket)
                    .WithMany(c => c.Motherboards)
                    .HasForeignKey(m => m.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Motherboards");
                entity.HasOne(m => m.GpuSocket)
                    .WithMany()
                    .HasForeignKey(m => m.GpuSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_GpuSocket");
                entity.HasOne(m => m.Processor)
                    .WithMany()
                    .HasForeignKey(m => m.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Processor");
                entity.HasOne(m => m.Gpu)
                    .WithMany()
                    .HasForeignKey(m => m.GpuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Gpu");
                entity.HasOne(m => m.Ram)
                    .WithMany()
                    .HasForeignKey(m => m.RamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Ram");
                entity.HasOne(m => m.Memory)
                    .WithMany()
                    .HasForeignKey(m => m.MemoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Memory");
                entity.HasKey(b => b.Id);

            });


            modelBuilder.Entity<PowerSupply>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PowerSupply_Brand");
            modelBuilder.Entity<PowerSupply>().HasKey(b => b.Id);




            modelBuilder.Entity<Processor>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Processor_Brand");
            modelBuilder.Entity<Processor>()
                .HasOne(m => m.ProcessorSocket)
                .WithMany()
                .HasForeignKey(m => m.ProcessorSocketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Processor_ProcessorSocket");
            modelBuilder.Entity<Processor>().HasKey(b => b.Id);




            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Gpu_Brand");
            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.GpuSocket)
                .WithMany()
                .HasForeignKey(m => m.GpuSocketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Gpu_GpuSocket");
            modelBuilder.Entity<Gpu>()
                .HasOne(m => m.FormFactor)
                .WithMany()
                .HasForeignKey(m => m.FormFactorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gpu_FormFactor");
            modelBuilder.Entity<Gpu>().HasKey(b => b.Id);



            modelBuilder.Entity<CPUCooler>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPUCooler_Brand");
            modelBuilder.Entity<CPUCooler>().HasKey(b => b.Id);



            modelBuilder.Entity<Ram>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ram_Brand");
            modelBuilder.Entity<Ram>().HasKey(b => b.Id);



            modelBuilder.Entity<Memory>()
                .HasOne(m => m.Brand)
                .WithMany()
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Memory_Brand");
            modelBuilder.Entity<Memory>().HasKey(b => b.Id);

            */

            /*

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Cases");
                entity.HasOne(d => d.Brand)
                    .WithMany()
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Brand");
                entity.HasOne(d => d.PowerSupply)
                    .WithMany()
                    .HasForeignKey(d => d.PowerSupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_PowerSupply");
                entity.HasOne(d => d.Motherboard)
                    .WithOne()
                    .HasForeignKey<Case>(d => d.MotherboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Motherboard");
            });

            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.ToTable("Motherboards");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Brand");

                // FormFactor relationship
                entity.HasOne(m => m.FormFactor)
                    .WithMany()
                    .HasForeignKey(m => m.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_FormFactor");

                // ProcessorSocket relationship
                entity.HasOne(m => m.ProcessorSocket)
                    .WithMany(c => c.Motherboards)
                    .HasForeignKey(m => m.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_ProcessorSocket");

                // GpuSocket relationship
                entity.HasOne(m => m.GpuSocket)
                    .WithMany()
                    .HasForeignKey(m => m.GpuSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_GpuSocket");

                // Processor relationship
                entity.HasOne(m => m.Processor)
                    .WithMany()
                    .HasForeignKey(m => m.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Processor");

                // Gpu relationship
                entity.HasOne(m => m.Gpu)
                    .WithMany()
                    .HasForeignKey(m => m.GpuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Gpu");

                // Ram relationship
                entity.HasOne(m => m.Ram)
                    .WithMany()
                    .HasForeignKey(m => m.RamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Ram");

                // Memory relationship
                entity.HasOne(m => m.Memory)
                    .WithMany()
                    .HasForeignKey(m => m.MemoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Memory");
            });

            modelBuilder.Entity<PowerSupply>(entity =>
            {
                entity.ToTable("PowerSupplies");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowerSupply_Brand");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("Processors");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processor_Brand");

                // ProcessorSocket relationship
                entity.HasOne(m => m.ProcessorSocket)
                    .WithMany()
                    .HasForeignKey(m => m.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processor_ProcessorSocket");
            });

            modelBuilder.Entity<Gpu>(entity =>
            {
                entity.ToTable("GPUs");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_Brand");

                // GpuSocket relationship
                entity.HasOne(m => m.GpuSocket)
                    .WithMany()
                    .HasForeignKey(m => m.GpuSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_GpuSocket");

                // FormFactor relationship
                entity.HasOne(m => m.FormFactor)
                    .WithMany()
                    .HasForeignKey(m => m.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_FormFactor");
            });

            modelBuilder.Entity<CPUCooler>(entity =>
            {
                entity.ToTable("CPUCoolers");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPUCooler_Brand");
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.ToTable("RAM");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ram_Brand");
            });

            modelBuilder.Entity<Memory>(entity =>
            {
                entity.ToTable("Memories");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Memory_Brand");
            });


            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            modelBuilder.Entity<FormFactor>().HasKey(b => b.Id);
            modelBuilder.Entity<ProcessorSocket>().HasKey(b => b.Id);
            modelBuilder.Entity<GpuSocket>().HasKey(b => b.Id);


            */



            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Cases");
                entity.HasOne(d => d.Brand)
                    .WithMany()
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Brand");
                entity.HasOne(d => d.PowerSupply)
                    .WithMany()
                    .HasForeignKey(d => d.PowerSupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_PowerSupply");
                entity.HasOne(d => d.Motherboard)
                    .WithOne()  // This should be WithOne(m => m.Case)
                    .HasForeignKey<Case>(d => d.MotherboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Motherboard");
            });

            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.ToTable("Motherboards");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Brand");

                // FormFactor relationship
                entity.HasOne(m => m.FormFactor)
                    .WithMany()
                    .HasForeignKey(m => m.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_FormFactor");

                // ProcessorSocket relationship
                entity.HasOne(m => m.ProcessorSocket)
                    .WithMany(c => c.Motherboards)
                    .HasForeignKey(m => m.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_ProcessorSocket");

                // GpuSocket relationship
                entity.HasOne(m => m.GpuSocket)
                    .WithMany()
                    .HasForeignKey(m => m.GpuSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_GpuSocket");

                // Processor relationship
                entity.HasOne(m => m.Processor)
                    .WithMany()
                    .HasForeignKey(m => m.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Processor");

                // Gpu relationship
                entity.HasOne(m => m.Gpu)
                    .WithMany()
                    .HasForeignKey(m => m.GpuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Gpu");

                // Ram relationship
                entity.HasOne(m => m.Ram)
                    .WithMany()
                    .HasForeignKey(m => m.RamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Ram");

                // Memory relationship
                entity.HasOne(m => m.Memory)
                    .WithMany()
                    .HasForeignKey(m => m.MemoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motherboard_Memory");
            });

            modelBuilder.Entity<PowerSupply>(entity =>
            {
                entity.ToTable("PowerSupplies");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowerSupply_Brand");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("Processors");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processor_Brand");

                // ProcessorSocket relationship
                entity.HasOne(m => m.ProcessorSocket)
                    .WithMany()
                    .HasForeignKey(m => m.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processor_ProcessorSocket");
            });

            modelBuilder.Entity<Gpu>(entity =>
            {
                entity.ToTable("GPUs");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_Brand");

                // GpuSocket relationship
                entity.HasOne(m => m.GpuSocket)
                    .WithMany()
                    .HasForeignKey(m => m.GpuSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_GpuSocket");

                // FormFactor relationship
                entity.HasOne(m => m.FormFactor)
                    .WithMany()
                    .HasForeignKey(m => m.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gpu_FormFactor");
            });

            modelBuilder.Entity<CPUCooler>(entity =>
            {
                entity.ToTable("CPUCoolers");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPUCooler_Brand");
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.ToTable("RAM");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ram_Brand");
            });

            modelBuilder.Entity<Memory>(entity =>
            {
                entity.ToTable("Memories");

                // Primary Key
                entity.HasKey(b => b.Id);

                // Brand relationship
                entity.HasOne(m => m.Brand)
                    .WithMany()
                    .HasForeignKey(m => m.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Memory_Brand");
            });


            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            modelBuilder.Entity<FormFactor>().HasKey(b => b.Id);
            modelBuilder.Entity<ProcessorSocket>().HasKey(b => b.Id);
            modelBuilder.Entity<GpuSocket>().HasKey(b => b.Id);





        }


    }
}
