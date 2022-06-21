namespace Idk.Application.Tenant.Film;

public class FilmMappingProfile : Profile {
   public FilmMappingProfile() {
      CreateMap<Domain.Tenant.Film, Queries.GetAll.Response.Film>();
   }
}
