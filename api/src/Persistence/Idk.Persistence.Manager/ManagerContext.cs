using Idk.Persistence.Common;
using Idk.Persistence.Manager.Models;

using Microsoft.EntityFrameworkCore;

namespace Idk.Persistence.Manager;

#nullable disable

public class ManagerContext : DbContext {
   public ManagerContext() { }
   public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

   public virtual DbSet<DbTenant> Tenants { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<DbTenant>(entity => entity.HasKey(e => e.Id));

      modelBuilder.ApplyDefaultValues();
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured)
         optionsBuilder.UseSqlServer(connectionString: "Data Source=localhost;Initial Catalog=IdkManager;Integrated Security=True");
   }

   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
      configurationBuilder.Properties<DateOnly>()
         .HaveConversion<DateOnlyConverter>()
         .HaveColumnType("date");

      configurationBuilder.Properties<DateOnly?>()
         .HaveConversion<NullableDateOnlyConverter>()
         .HaveColumnType("date");
   }
}
