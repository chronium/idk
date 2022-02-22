using Microsoft.Extensions.DependencyInjection;

namespace Idk.DataAccess.Manager.EF;

public static class ServiceRegistrar {
   public static void RegisterManagerDataAccess(this IServiceCollection collection) {
      collection.AddScoped<ITenantDataService, TenantDataService>();
   }
}
