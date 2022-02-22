using Idk.Domain.Manager;
using Idk.Persistence.Manager;
using Idk.Persistence.Manager.Models;

namespace Idk.DataAccess.Manager.EF;

public class TenantDataService : ITenantDataService {
   private readonly ManagerContext context;

   public TenantDataService(ManagerContext context) => this.context = context;

   public IEnumerable<Tenant> GetAll()
      => context.Tenants.AsQueryable().Select(Tenant.Of);

   public Tenant? GetById(Guid id) 
      => Tenant.Maybe(context.Tenants.SingleOrDefault(t => t.Id == id));

   public Tenant InsertSave(string name, string subdomain) {
      var entity = context.Tenants.Add(new DbTenant {
         Name = name,
         Subdomain = subdomain
      }).Entity;
      context.SaveChanges();
      return Tenant.Of(entity);
   }
}
