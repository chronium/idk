namespace Idk.Application.Tenant.Title.Queries.GetAll;

public record Response {
   public List<Title> Titles { get; set; } = default!;

   public record Title(
      Guid Id,
      string Name,
      string Image,
      TitleKind Kind,
      string StartDate,
      string? EndDate
   );

   public enum TitleKind {
      Series,
      Film
   }
}
