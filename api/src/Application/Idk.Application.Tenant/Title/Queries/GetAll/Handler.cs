namespace Idk.Application.Tenant.Title.Queries.GetAll;

public class Handler : IRequestHandler<Request, Response> {
   private readonly ITitleDataService titleData;
   private readonly IMapper mapper;

   public Handler(ITitleDataService titleData, IMapper mapper) {
      this.titleData = titleData;
      this.mapper = mapper;
   }

   public Task<Response> Handle(Request request, CancellationToken cancellationToken)
      => Task.FromResult(new Response {
         Titles = mapper.Map<List<Response.Title>>(titleData.GetAll())
      });
}
