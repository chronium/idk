namespace Idk.API.Controllers.Manager;

using Get = Application.Manager.Tenant.Queries.Get;
using GetAll = Application.Manager.Tenant.Queries.GetAll;
using Create = Application.Manager.Tenant.Commands.Create;

[ApiController]
[Structure.ManagerApiGroup]
[Route("manager/[controller]")]
public class TenantController : ControllerBase {

   private readonly IMediator mediator;

   public TenantController(IMediator mediator) => this.mediator = mediator;

   [HttpGet]
   public Task<GetAll.Response> GetAll() 
      => mediator
         .Send(new GetAll.Request());

   [HttpGet("{id}", Name = "GetById")]
   [ProducesResponseType(typeof(Get.Response), StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public Task<IResponse<Get.Response>> Get(Guid id)
      => mediator
         .Send(new Get.Request(id))
         .AsQueryResponse();

   [HttpPost("create")]
   [ProducesResponseType(201, Type = typeof(Create.Response))]
   public Task<IResponse<Create.Response>> Create([FromBody] Create.Request request)
      => mediator
         .Send(request)
         .AsCreatedResponse(tenant => tenant.Id, "GetById");
}
