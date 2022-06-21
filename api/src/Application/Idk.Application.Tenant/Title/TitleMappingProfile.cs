namespace Idk.Application.Tenant.Title;

public class TitleMappingProfile : Profile {
   public TitleMappingProfile() {
      CreateMap<Domain.Tenant.Title, Queries.GetAll.Response.Title>();
      CreateMap<Domain.Tenant.Title, Commands.Create.Response>();
      CreateMap<Domain.Tenant.Title?, Queries.Get.Response?>();
   }
}
