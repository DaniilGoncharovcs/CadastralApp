namespace CadastralWebApp.Middleware;

public static class CustomExceptionHandler
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        => app.UseMiddleware<CustomExceptionHandlerMiddleware>();
}