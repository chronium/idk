namespace Idk.API.Controllers.Manager;

using Create = Application.Manager.Tenant.Commands.Create;
using Get = Application.Manager.Tenant.Queries.Get;
using GetAll = Application.Manager.Tenant.Queries.GetAll;

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
         .AsCreatedResponse(tenant => tenant.Id, "Tenant/GetById");

   //"IdkManager": "Data Source=localhost;Initial Catalog=IdkManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
   // "IdkTenant": "Data Source=localhost;Initial Catalog=IdkTenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  
}