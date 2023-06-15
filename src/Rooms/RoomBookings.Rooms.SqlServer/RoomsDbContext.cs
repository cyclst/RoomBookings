using Microsoft.EntityFrameworkCore;
using RoomBookings.Common.Application.DomainEvents;
using RoomBookings.Common.SqlServer;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.SqlServer
{
    public class RoomsDbContext : BaseDbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public RoomsDbContext(IDomainEventPublisher domainEventPublisher, DbContextOptions<RoomsDbContext> options) : base(domainEventPublisher, options)
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