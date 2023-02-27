namespace CadastralApplication.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
        => ApplyMigrationsFromAssembly(assembly);

    private void ApplyMigrationsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
                    .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && 
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                    .ToList();

        foreach(var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}