using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RoomBookings.Rooms.SqlServer;

public class RoomsDbContextInitialiser
{
    private readonly ILogger<RoomsDbContextInitialiser> _logger;
    private readonly RoomsDbContext _context;

    public RoomsDbContextInitialiser(ILogger<RoomsDbContextInitialiser> logger, RoomsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.Rooms.Any())
        {
            //_context.Rooms.Add(new Room
            //{
            //});

            //await _context.SaveChangesAsync();
        }
    }
}
