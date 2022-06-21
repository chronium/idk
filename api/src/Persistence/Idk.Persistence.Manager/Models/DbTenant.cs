namespace Idk.Persistence.Manager.Models;

[Table("Tenant")]
public class DbTenant {
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public Guid Id { get; set; } = default!;

   [Required]
   [MaxLength(128)]
   public string Name { get; set; } = default!;

   [Required]
   [MaxLength(63)]
   public string Subdomain { get; set; } = default!;
}
