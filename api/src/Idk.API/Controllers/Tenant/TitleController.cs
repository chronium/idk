namespace Idk.API.Controllers.Tenant;

using Create = Application.Tenant.Title.Commands.Create;
using GetAll = Application.Tenant.Title.Queries.GetAll;
using Get = Application.Tenant.Title.Queries.Get;

[ApiController]
[Structure.TenantApiGroup]
[Route("tenant/[controller]")]
public class TitleController {
   private readonly IMediator mediator;

   public TitleController(IMediator mediator) => this.mediator = mediator;

   [HttpGet]
   public Task<GetAll.Response> GetAll()
      => mediator
         .Send(new GetAll.Request());

   [HttpGet("{id}", Name = "[controller]/GetById")]
   [ProducesResponseType(typeof(Get.Response), StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public Task<IResponse<Get.Response>> Get(Guid id)
      => mediator
         .Send(new Get.Request(id))
         .AsQueryResponse();

   [HttpPost("Create")]
   [ProducesResponseType(typeof(Create.Response), StatusCodes.Status201Created)]
   public Task<IResponse<Create.Response>> Create([FromBody] Create.Request request)
      => mediator
         .Send(request)
         .AsCreatedResponse(title => title.Id, "Title/GetById");
}
