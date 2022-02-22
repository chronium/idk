namespace Idk.Application.Manager.Tenant.Queries.Get;

public record Request(Guid Id) : IRequest<Response?>;