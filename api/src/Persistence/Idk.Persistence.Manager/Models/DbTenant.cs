namespace Idk.Persistence.Manager.Models;

[Table("Tenant")]
public class DbTenant {
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public Guid Id { get; set; } = default!;
   [MaxLength(128)]
   [Required]
   public string Name { get; set; } = default!;
   [MaxLength(63)]
   [Required]
   public string Subdomain { get; set; } = default!;
}
