namespace Idk.Domain.Tenant;

public class Title {
   public Guid Id { get; set; } = default!;
   
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

   public static Title Of(DbTitle dbTitle)
      => new() {
         Id = TitleId.Of(dbTitle.Id),
         Name = dbTitle.Name,
         Image = dbTitle.Image,
         Kind = (TitleKind)dbTitle.Kind,
         StartDate = dbTitle.StartDate,
         EndDate = dbTitle.EndDate
      };

   public static Title? Maybe(DbTitle? dbTitle)
      => dbTitle is null ? null : Of(dbTitle);
}
