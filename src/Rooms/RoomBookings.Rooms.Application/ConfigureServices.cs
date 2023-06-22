using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace RoomBookings.Rooms.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

        });

        return services;
    }
}
