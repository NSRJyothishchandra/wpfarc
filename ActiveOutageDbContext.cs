//using Microsoft.EntityFrameworkCore;
//using ActiveOutageApi.Models;
//using Microsoft.Extensions.Configuration;
//using System.IO;
//using ActiveOutageApi.VmOms;

//namespace ActiveOutageApi.Data
//{
//    public class ActiveOutageDbContext : DbContext
//    {
//        public ActiveOutageDbContext(DbContextOptions<ActiveOutageDbContext> options) : base(options)
//        {
//        }

//        public DbSet<ActiveOutage> ActiveOutages { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<ActiveOutage>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToView("view_active_outages");

//                entity.Property(e => e.Boundary).HasColumnType("string");

//                entity.Property(e => e.CaseNumber)
//                    .IsRequired()
//                    .HasMaxLength(20);

//                entity.Property(e => e.Cause).HasMaxLength(255);

//                entity.Property(e => e.County).HasMaxLength(50);

//                entity.Property(e => e.ElementType).HasMaxLength(20);

//                entity.Property(e => e.Etor).HasColumnName("ETOR");

//                entity.Property(e => e.Failure).HasMaxLength(255);

//                entity.Property(e => e.IsCrewAssigned).HasColumnName("Is_Crew_Assigned");

//                entity.Property(e => e.Latitude).HasColumnType("numeric(38, 8)");

//                entity.Property(e => e.Longitude).HasColumnType("numeric(38, 8)");

//                entity.Property(e => e.MessageToCustomers).HasColumnName("Message_To_Customers");

//                entity.Property(e => e.OtherReason)
//                    .HasMaxLength(255)
//                    .HasColumnName("Other_Reason");

//                entity.Property(e => e.Phase)
//                    .HasMaxLength(3)
//                    .IsUnicode(false)
//                    .IsFixedLength(true);

//                entity.Property(e => e.Region).HasMaxLength(50);

//                entity.Property(e => e.StartedOn).HasColumnName("Started_On");

//                entity.Property(e => e.State).HasMaxLength(50);

//                entity.Property(e => e.Status).HasMaxLength(20);

//                entity.Property(e => e.TotalImpactedCustomers)
//                    .HasColumnType("numeric(8, 2)")
//                    .HasColumnName("Total_Impacted_Customers");
//                entity.Property(e => e.AffectedCustomers);

//                entity.Property(e => e.Weather).HasMaxLength(255);
//            });
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                var builder = new ConfigurationBuilder()
//                    .SetBasePath(Directory.GetCurrentDirectory())
//                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//                var configuration = builder.Build();

//                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
//                    sqlServerOptionsAction: options => options.UseNetTopologySuite());
//            }
//        }
//        public DbSet<ActiveOutageApi.VmOms.CountyOms> CountyOms { get; set; } = default!;
//        public DbSet<ActiveOutageApi.VmOms.RegionOms> RegionOms { get; set; } = default!;
//    }
//}



using Microsoft.EntityFrameworkCore;
using ActiveOutageApi.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using ActiveOutageApi.VmOms;
using NetTopologySuite.Geometries;

namespace ActiveOutageApi.Data
{
    public class ActiveOutageDbContext : DbContext
    {
        public ActiveOutageDbContext(DbContextOptions<ActiveOutageDbContext> options) : base(options)
        {
        }

        public DbSet<ActiveOutage> ActiveOutages { get; set; }
        public DbSet<CountyOms> CountyOms { get; set; }
        public DbSet<RegionOms> RegionOms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveOutage>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_active_outages");
                entity.Property(e => e.Boundary).HasColumnType("string");
                entity.Property(e => e.CaseNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Cause).HasMaxLength(255);
                entity.Property(e => e.County).HasMaxLength(50);
                entity.Property(e => e.ElementType).HasMaxLength(20);
                entity.Property(e => e.Etor).HasColumnName("ETOR");
                entity.Property(e => e.Failure).HasMaxLength(255);
                entity.Property(e => e.IsCrewAssigned).HasColumnName("Is_Crew_Assigned");
                entity.Property(e => e.Latitude).HasColumnType("numeric(38, 8)");
                entity.Property(e => e.Longitude).HasColumnType("numeric(38, 8)");
                entity.Property(e => e.MessageToCustomers).HasColumnName("Message_To_Customers");
                entity.Property(e => e.OtherReason).HasMaxLength(255).HasColumnName("Other_Reason");
                entity.Property(e => e.Phase).HasMaxLength(3).IsUnicode(false).IsFixedLength(true);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.Property(e => e.StartedOn).HasColumnName("Started_On");
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.TotalImpactedCustomers).HasColumnType("numeric(8, 2)").HasColumnName("Total_Impacted_Customers");
                entity.Property(e => e.AffectedCustomers);
                entity.Property(e => e.Weather).HasMaxLength(255);
            });

            modelBuilder.Entity<CountyOms>(entity =>
            {
                entity.ToTable("vm_oms_pom_county");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.CustomersServed);
                entity.Property(e => e.NoOfOutages);
                entity.Property(e => e.TotalCustOut);
                entity.Property(e => e.Shape).HasColumnType("geometry");
            });
             modelBuilder.Entity<RegionOms>(entity =>
            {
                entity.ToTable("vm_oms_pom_Region");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.CustomersServed);
                entity.Property(e => e.NoOfOutages);
                entity.Property(e => e.TotalCustOut);
                entity.Property(e => e.Shape).HasColumnType("geometry");
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: options => options.UseNetTopologySuite());
            }
        }
    }
}
