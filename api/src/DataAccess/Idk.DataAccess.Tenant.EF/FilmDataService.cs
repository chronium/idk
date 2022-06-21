namespace Idk.DataAccess.Tenant.EF;

public class FilmDataService : IFilmDataService {
   private readonly TenantContext context;

   public FilmDataService(TenantContext context) => this.context = context;

   public IEnumerable<Film> GetAll() 
      => context.Films.AsQueryable().Select(Film.Of);
}
