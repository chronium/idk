namespace Idk.Application.Tenant.Title.Commands.Create;

public record Request(string Name, string Image, TitleKind Kind, string StartDate, string? EndDate) : IRequest<Response>;
