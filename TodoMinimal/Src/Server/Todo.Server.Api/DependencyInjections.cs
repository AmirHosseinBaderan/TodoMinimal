using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Todo.Server.Api;

public static class DependencyInjections
{
    private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

    public static IServiceCollection ConfigureMapster(this IServiceCollection services)
    {
        var typeAdaperConfig = TypeAdapterConfig.GlobalSettings;
        typeAdaperConfig.Scan(Assemblies);

        services.AddSingleton(typeAdaperConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }



}
