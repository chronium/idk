namespace Idk.Application.Manager.Tenant.Commands.Create;

public record Request(string Name, string Subdomain) : IRequest<Response>;
