namespace Idk.Persistence.Tenant.Models;

[Table("Film")]
public class DbFilm : DbTenantEntity {
   [Required]
   [MaxLength(256)]
   public string Name { get; set; } = default!;

   public DateOnly? ReleaseDate { get; set; }
}
