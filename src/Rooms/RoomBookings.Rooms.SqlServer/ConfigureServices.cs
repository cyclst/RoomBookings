using Cyclst.CleanArchitecture.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using RoomBookings.Rooms.Application.Command;

namespace RoomBookings.Rooms.SqlServer;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<RoomsDbContext>(options =>
                options.UseInMemoryDatabase("RoomBookingsDb"));
        }
        else
        {
            services.AddDbContext<RoomsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(RoomsDbContext).Assembly.FullName)), ServiceLifetime.Scoped);
        }

        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<RoomsDbContext>());

        services.AddScoped<RoomsDbContextInitialiser>();

        services.AddScoped<IRoomRepository, RoomRepository>();


        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
