namespace Idk.Application.Tenant.Film.Queries.GetAll;

public record Response {
   public List<Film> Films { get; set; } = default!;

   public record Film(Guid Id, string Name, DateOnly? ReleaseDate);
}
