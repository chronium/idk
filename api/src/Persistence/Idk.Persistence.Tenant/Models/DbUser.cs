namespace Idk.Persistence.Tenant.Models;

[Table("User")]
public class DbUser : DbTenantEntity {
   [Required]
   [MaxLength(128)]
   public string Name { get; set; } = default!;
}
