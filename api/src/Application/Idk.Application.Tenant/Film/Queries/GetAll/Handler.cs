namespace Idk.Application.Tenant.Film.Queries.GetAll;

public class Handler : IRequestHandler<Request, Response> {
   private readonly IFilmDataService filmData;
   private readonly IMapper mapper;

   public Handler(IFilmDataService filmData, IMapper mapper) {
      this.filmData = filmData;
      this.mapper = mapper;
   }

   public Task<Response> Handle(Request request, CancellationToken cancellationToken)
      => Task.FromResult(new Response {
         Films = mapper.Map<List<Response.Film>>(filmData.GetAll())
      });
}
