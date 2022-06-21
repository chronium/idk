namespace Idk.Domain.Tenant;

public class Film {
   public Guid Id { get; set; } = default!;

   [Required]
   [MaxLength(256)]
   public string Name { get; set; } = default!;

   public DateOnly? ReleaseDate { get; set; }

   public static Film Of(DbFilm dbFilm)
      => new() {
         Id = FilmId.Of(dbFilm.Id),
         Name = dbFilm.Name,
         ReleaseDate = dbFilm.ReleaseDate
      };

   public static Film? Maybe(DbFilm? dbFilm)
      => dbFilm is null ? null : Of(dbFilm);
}
