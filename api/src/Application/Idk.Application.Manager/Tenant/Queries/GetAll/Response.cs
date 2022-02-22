namespace Idk.Application.Manager.Tenant.Queries.GetAll;

public record Response {
   public List<Tenant> Tenants { get; set; } = default!;

   public record Tenant(Guid Id, string Name, string Subdomain);
}
