using Microsoft.Extensions.DependencyInjection;
using RoomBookings.Rooms.Application.Command;

namespace RoomBookings.Rooms.Api.FunctionalTests;

public abstract class TestFixtureBase : IClassFixture<TestApplicationFactory>, IAsyncLifetime
{
    protected TestApplicationFactory Factory { get; }
    protected HttpClient Client { get; }

    protected IRoomRepository RoomRepository { get; private set; }

    protected TestFixtureBase(TestApplicationFactory factory)
    {
        Factory = factory;
        Client = factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        using (var scope = Factory.Services.CreateScope())
        {
            RoomRepository = scope.ServiceProvider.GetRequiredService<IRoomRepository>();
        }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
