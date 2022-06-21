using Microsoft.Extensions.DependencyInjection;

namespace Idk.DataAccess.Tenant.EF;

public static class ServiceRegistrar {
   public static void RegisterTenantDataAccess(this IServiceCollection collection) {
      collection.AddScoped<IFilmDataService, FilmDataService>();
      collection.AddScoped<IUserDataService, UserDataService>();
      collection.AddScoped<ITitleDataService, TitleDataService>();
   }
}
