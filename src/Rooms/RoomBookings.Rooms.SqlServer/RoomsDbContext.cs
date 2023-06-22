using Cyclst.CleanArchitecture.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.SqlServer
{
    public class RoomsDbContext : DbContext, IDbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public RoomsDbContext(DbContextOptions<RoomsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Room>()
                .OwnsMany(l => l.Beds, b => { b.ToJson(); });

            modelBuilder
                .Entity<Room>()
                .OwnsOne(l => l.Facilities, b => { b.ToJson(); });

            modelBuilder
                .Entity<Room>()
                .OwnsOne(l => l.Address, b => { b.ToJson(); });

            modelBuilder
                .Entity<Room>()
                .OwnsMany(l => l.BookingDurationDiscounts, b => { b.ToJson(); });
        }
    }
}