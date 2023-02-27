namespace CadastralWebApp.Middleware;

public class SwaggerAuthorizedMiddleware
{
    private readonly RequestDelegate _next;

	public SwaggerAuthorizedMiddleware(RequestDelegate next)
		=> _next = next;

	public async Task Invoke(HttpContext httpContext)
	{
		if(httpContext.Request.Path.StartsWithSegments("/swagger")
			&& !httpContext.User.Identity.IsAuthenticated)
		{
			httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
			return;
		}

		await _next.Invoke(httpContext);
	}
}