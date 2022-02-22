using Idk.Domain.Manager;

namespace Idk.DataAccess.Manager;

public interface ITenantDataService {
   public IEnumerable<Tenant> GetAll();
   public Tenant? GetById(Guid id);

   public Tenant InsertSave(string name, string subdomain);
}
