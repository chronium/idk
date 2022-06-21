namespace Idk.Application.Tenant.Title.Commands.Create;

public class Handler : IRequestHandler<Request, Response> {
   private readonly ITitleDataService titleData;
   private readonly IMapper mapper;

   public Handler(ITitleDataService titleData, IMapper mapper) {
      this.titleData = titleData;
      this.mapper = mapper;
   }

   public Task<Response> Handle(Request request, CancellationToken cancellationToken)
      => Task.FromResult(
         mapper.Map<Response>(
            titleData.InsertSave(
               request.Name, 
               request.Image, 
               (int)request.Kind, 
               DateOnly.ParseExact(request.StartDate, new[] { "yyyy" }), 
               !string.IsNullOrEmpty(request.EndDate) ? DateOnly.ParseExact(request.EndDate, new[] { "yyyy" }) : null)));
}
