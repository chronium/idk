namespace Idk.Application.Tenant.Title.Queries.Get;

public record Request(Guid Id) : IRequest<Response?>;
