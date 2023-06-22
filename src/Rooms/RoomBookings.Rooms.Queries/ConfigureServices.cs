using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RoomBookings.Rooms.Queries;

public static class ConfigureServices
{
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

        });

        return services;
    }
}
