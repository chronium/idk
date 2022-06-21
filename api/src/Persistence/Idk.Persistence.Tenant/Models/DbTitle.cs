namespace Idk.Persistence.Tenant.Models;

[Table("Title")]
public class DbTitle : DbTenantEntity {
   [Required]
   [MaxLength(256)]
   public string Name { get; set; } = default!;

   [Required]
   [MaxLength(256)]
   public string Image { get; set; } = default!;

   [Required]
   public TitleKind Kind { get; set; } = default!;

   [Required]
   public DateOnly StartDate { get; set; } = default!;

   public DateOnly? EndDate { get; set; }
   
   public enum TitleKind {
      Series,
      Film
   }
}
