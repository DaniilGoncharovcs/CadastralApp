namespace CadastralPersistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connection)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connection);
        });

        services.AddScoped<IAppDbContext>(provider =>
            provider.GetService<AppDbContext>());

        return services;
    }
}