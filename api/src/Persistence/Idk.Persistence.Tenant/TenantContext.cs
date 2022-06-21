using Idk.Persistence.Common;
using Idk.Persistence.Tenant.Models;

using Microsoft.EntityFrameworkCore;

namespace Idk.Persistence.Tenant;

#nullable disable

public class TenantContext : DbContext {
   public TenantContext() { }
   public TenantContext(DbContextOptions<TenantContext> options) : base (options) { }

   public virtual DbSet<DbUser> Users { get; set; }
   public virtual DbSet<DbFilm> Films { get; set; }
   public virtual DbSet<DbTitle> Titles { get; set; }

   private readonly Guid _tenantId = new("32e8e62a-931b-4cb6-8d6c-4fabb73da9fe");

   protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<DbUser>().HasTenantId(_tenantId).HasKey(e => new { e.TenantId, e.Id });
      modelBuilder.Entity<DbFilm>().HasTenantId(_tenantId).HasKey(e => new { e.TenantId, e.Id });
      modelBuilder.Entity<DbTitle>().HasTenantId(_tenantId).HasKey(e => new { e.TenantId, e.Id });

      modelBuilder.ApplyDefaultValues();
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured)
         optionsBuilder.UseSqlServer(connectionString: "Data Source=localhost;Initial Catalog=IdkTenant;Integrated Security=True");
   }

   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
      configurationBuilder.Properties<DateOnly>()
         .HaveConversion<DateOnlyConverter>()
         .HaveColumnType("date");

      configurationBuilder.Properties<DateOnly?>()
         .HaveConversion<NullableDateOnlyConverter>()
         .HaveColumnType("date");
   }

   public override int SaveChanges() {

      var addedEntities = ChangeTracker.Entries().Where(c => c.State == EntityState.Added)
          .Select(c => c.Entity).OfType<DbTenantEntity>();

      foreach (var entity in addedEntities) {
         entity.TenantId = _tenantId;
      }
      return base.SaveChanges();
   }
}
