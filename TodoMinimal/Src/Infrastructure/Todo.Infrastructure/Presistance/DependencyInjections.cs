using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure.Presistance;

namespace Infrastructure.Presistance;

public static class DependencyInjections
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<TodoDbContext>(options => options
                                                   .UseSqlServer(configuration
                                                   .GetConnectionString(TodoDbContextSchema
                                                                        .DefaultConnectionStringName)));

        services.AddScoped(typeof(IBaseCud<>), typeof(BaseCud<>));
        services.AddScoped(typeof(IBaseQuery<>), typeof(BaseQuery<>));

        return services;
    }
}
