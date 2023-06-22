using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.SqlServer;

namespace RoomBookings.Rooms.Api.FunctionalTests;

public abstract class TestFixtureBase : IClassFixture<TestApplicationFactory>, IAsyncLifetime
{
    private readonly IConfiguration _configuration;
    private Respawner _checkpoint;

    protected TestApplicationFactory Factory { get; }
    protected HttpClient Client { get; private set; }

    protected IRoomRepository RoomRepository => GetRoomRepository();
    protected RoomsDbContext RoomsDbContext => GetRoomsDbContext();

    protected TestFixtureBase(TestApplicationFactory factory)
    {
        Factory = factory;
        _configuration = Factory.Services.GetRequiredService<IConfiguration>();
    }

    public async Task InitializeAsync()
    {
        Client = Factory.CreateClient();

        _checkpoint = Respawner.CreateAsync(_configuration.GetConnectionString("DefaultConnection")!, new RespawnerOptions
        {
            TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
        }).GetAwaiter().GetResult();

        await ResetState();
    }

    public IRoomRepository GetRoomRepository()
    {
        using (var scope = Factory.Services.CreateScope())
        {
            return scope.ServiceProvider.GetRequiredService<IRoomRepository>();
        }
    }
    public RoomsDbContext GetRoomsDbContext()
    {
        using (var scope = Factory.Services.CreateScope())
        {
            return scope.ServiceProvider.GetRequiredService<RoomsDbContext>();
        }
    }

    public async Task ResetState()
    {
        try
        {
            await _checkpoint.ResetAsync(_configuration.GetConnectionString("DefaultConnection")!);
        }
        catch (Exception)
        {
        }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
