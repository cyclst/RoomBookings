using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.SqlServer;

namespace RoomBookings.Rooms.Api.FunctionalTests;

public class TestApplicationFactory : WebApplicationFactory<IApplicationMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder =>
        {
            var integrationConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            configurationBuilder.AddConfiguration(integrationConfig);
        });

        builder.ConfigureServices((builder, services) =>
        {
            services
                .Remove<DbContextOptions<RoomsDbContext>>()
                .AddDbContext<RoomsDbContext>((sp, options) =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(RoomsDbContext).Assembly.FullName)));
        });
    }
}