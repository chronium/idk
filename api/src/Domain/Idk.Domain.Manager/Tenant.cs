namespace Idk.Domain.Manager;

public class Tenant {
   public TenantId Id { get; set; } = default!;

   [MaxLength(128)]
   [Required]
   public string Name { get; set; } = default!;

   [MaxLength(63)]
   [Required]
   public string Subdomain { get; set; } = default!;

   public static Tenant Of(DbTenant dbTenant)
      => new() {
         Id = TenantId.Of(dbTenant.Id),
         Name = dbTenant.Name,
         Subdomain = dbTenant.Subdomain,
      };

   public static Tenant? Maybe(DbTenant? dbTenant)
      => dbTenant is null ? null : Of(dbTenant);
}
