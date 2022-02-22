using AutoMapper;

namespace Idk.Application.Manager.Tenant;

public class TenantMappingProfile : Profile {
   public TenantMappingProfile() {
      CreateMap<Domain.Manager.Tenant, Queries.GetAll.Response.Tenant>();
      CreateMap<Domain.Manager.Tenant, Commands.Create.Response>();
      CreateMap<Domain.Manager.Tenant?, Queries.Get.Response?>();
   }
}
