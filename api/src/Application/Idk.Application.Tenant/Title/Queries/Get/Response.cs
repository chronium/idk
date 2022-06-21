namespace Idk.Application.Tenant.Title.Queries.Get;

public record Response(
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
