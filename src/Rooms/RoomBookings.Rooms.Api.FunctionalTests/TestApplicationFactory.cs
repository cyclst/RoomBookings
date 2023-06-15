using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RoomBookings.Rooms.Application.Command;

namespace RoomBookings.Rooms.Api.FunctionalTests
{
    public class TestApplicationFactory : WebApplicationFactory<Application.Api.Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterType<InMemoryRoomRepository>().As<IRoomRepository>().SingleInstance();
            });

            builder.ConfigureHostConfiguration((config) =>
            {
                config.AddInMemoryCollection(
                    new Dictionary<string, string?>
                    {
                        ["ConnectionString"] = @"NOTUSED"
                    });
            });

            return base.CreateHost(builder);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
        }
    }
}
