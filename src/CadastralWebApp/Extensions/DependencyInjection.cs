using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.OpenApi.Models;

namespace CadastralWebApp.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddDefaultIdentity<AppUser>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddApiVersioning();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cadastral Web API",
                Version = "v1"
            });
        });

        return services;
    }

    public static IServiceCollection AddHttpClients(this IServiceCollection services, Uri baseAddress)
    {
        services.AddHttpClient<IDocumentService, DocumentService>(client =>
        {
            client.BaseAddress = baseAddress;
        });

        return services;
    }
}