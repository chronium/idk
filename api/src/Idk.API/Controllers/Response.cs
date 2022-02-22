namespace Idk.API.Controllers;

public static class ResponseExtensions {
   public static IActionResult AsResult<T>(this T? response) 
      => new NotFoundResponse<T>(response);

   public static async Task<IResponse<T>> AsQueryResponse<T>(this Task<T?> response)
      => new NotFoundResponse<T>(await response);

   public static async Task<IResponse<T>> AsCreatedResponse<T>(this Task<T> response, Func<T, Guid> id, string route)
      => new CreatedResponse<T>(await response, id, route);
}

public interface IResponse<T> : IActionResult { }

public record NotFoundResponse<T>(T? Response) : IResponse<T> {
   public Task ExecuteResultAsync(ActionContext context) 
      => new NotFoundObjectResult(Response).ExecuteResultAsync(context);
}

public record CreatedResponse<T>(T Response, Func<T, Guid> Id, string Route) : IResponse<T> {
   public Task ExecuteResultAsync(ActionContext context)
      => new CreatedAtRouteResult(Route, new { Id = Id(Response) }, Response).ExecuteResultAsync(context);
}
