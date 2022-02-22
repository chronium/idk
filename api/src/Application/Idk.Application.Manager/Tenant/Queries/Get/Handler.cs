namespace Idk.Application.Manager.Tenant.Queries.Get;

public class Handler : IRequestHandler<Request, Response?> {
   private readonly ITenantDataService tenantData;
   private readonly IMapper mapper;

   public Handler(ITenantDataService tenantData, IMapper mapper) {
      this.tenantData = tenantData;
      this.mapper = mapper;
   }

   public Task<Response?> Handle(Request request, CancellationToken cancellationToken)
      => Task.FromResult(mapper.Map<Response?>(tenantData.GetById(request.Id)));
}
