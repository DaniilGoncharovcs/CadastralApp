namespace CadastralWebApp.Middleware;

public static class SwaggerAuthorized
{
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder app)
    {
        app.UseMiddleware<SwaggerAuthorizedMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}