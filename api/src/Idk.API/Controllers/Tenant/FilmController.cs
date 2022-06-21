namespace Idk.API.Controllers.Tenant;

using GetAll = Application.Tenant.Film.Queries.GetAll;

[ApiController]
[Structure.TenantApiGroup]
[Route("tenant/[controller]")]
public class FilmController: ControllerBase {
   private readonly IMediator mediator;

   public FilmController(IMediator mediator) => this.mediator = mediator;

   [HttpGet]
   public Task<GetAll.Response> GetAll()
      => mediator
         .Send(new GetAll.Request());
}
