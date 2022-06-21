namespace Idk.Application.Tenant.Title.Queries.Get;

public class Handler : IRequestHandler<Request, Response?> {
   private readonly ITitleDataService titleData;
   private readonly IMapper mapper;

   public Handler(ITitleDataService titleData, IMapper mapper) {
      this.titleData = titleData;
      this.mapper = mapper;
   }

   public Task<Response?> Handle(Request request, CancellationToken cancellationToken)
      => Task.FromResult(mapper.Map<Response?>(titleData.GetById(request.Id)));
}