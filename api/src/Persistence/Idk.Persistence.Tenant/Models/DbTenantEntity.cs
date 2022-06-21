namespace Idk.Persistence.Tenant.Models;

public class DbTenantEntity {
   [Key]
   [Column(Order = 1)]
   public Guid TenantId { get; set; } = default!;

   [Key]
   [Column(Order = 2)]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public Guid Id { get; set; } = default!;

   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public DateTimeOffset CreatedAt { get; set; }
   [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
   public DateTimeOffset UpdatedAt { get; set; }
}
