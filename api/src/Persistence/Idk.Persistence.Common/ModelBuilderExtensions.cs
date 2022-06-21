using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Idk.Persistence.Common;

public static class ModelBuilderExtensions {
   public static void ApplyDefaultValues(this ModelBuilder modelBuilder) {
      foreach (var entity in modelBuilder.Model.GetEntityTypes()) {
         var entityClass = entity.ClrType;

         foreach (var property in entityClass.GetProperties()
            .Where(p =>
               p.PropertyType == typeof(DateTime) ||
               p.PropertyType == typeof(DateOnly) ||
               p.PropertyType == typeof(DateTimeOffset) ||
               p.PropertyType == typeof(Guid))) {

            var defaultValueSql = "GetDate()";
            if (property.PropertyType == typeof(Guid)) {
               defaultValueSql = "newsequentialid()";
            }
            modelBuilder.Entity(entityClass).Property(property.Name).HasDefaultValueSql(defaultValueSql);
         }
      }
   }

   public static EntityTypeBuilder<TEntity> HasTenantId<TEntity>(this EntityTypeBuilder<TEntity> entity, Guid tenantId) 
      where TEntity : class 
      => entity.HasQueryFilter(e => EF.Property<Guid>(e, "TenantId") == tenantId);
}