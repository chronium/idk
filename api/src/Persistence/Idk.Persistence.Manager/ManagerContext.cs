using Idk.Persistence.Manager.Models;

using Microsoft.EntityFrameworkCore;

namespace Idk.Persistence.Manager;

#nullable disable

public class ManagerContext : DbContext
{
   public ManagerContext() { }
   public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

   public virtual DbSet<DbTenant> Tenants { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<DbTenant>(entity => entity.HasKey(e => e.Id));

      modelBuilder.ApplyDefaultValues();
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured)
         optionsBuilder.UseSqlServer(connectionString: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IdkManager");
   }
}

public static class ModelBuilderExtensions {

   public static void ApplyDefaultValues(this ModelBuilder modelBuilder) {
      foreach (var entity in modelBuilder.Model.GetEntityTypes()) {
         var entityClass = entity.ClrType;

         foreach (var property in entityClass.GetProperties()
            .Where(p =>
               p.PropertyType == typeof(DateTime) || 
               p.PropertyType == typeof(Guid))) {

            var defaultValueSql = "GetDate()";
            if (property.PropertyType == typeof(Guid)) {
               defaultValueSql = "newsequentialid()";
            }
            modelBuilder.Entity(entityClass).Property(property.Name).HasDefaultValueSql(defaultValueSql);
         }
      }
   }
}