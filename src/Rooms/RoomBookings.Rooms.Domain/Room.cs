using Cyclst.CleanArchitecture.Domain;
using RoomBookings.Rooms.Domain.DomainEvent;
using RoomBookings.Rooms.Domain.ValueObjects;

namespace RoomBookings.Rooms.Domain;

public class Room : BaseEntity
{
    public ICollection<Booking> Bookings { get; init; } = new List<Booking>();
    public Address Address { get; init; }
    public ICollection<Bed> Beds { get; init; } = new List<Bed>();
    public int MinimumBookingDurationDays { get; init; }
    public int? MaximumBookingDurationDays { get; init; }
    public double DailyPrice { get; init; }
    public ICollection<BookingDurationDiscount> BookingDurationDiscounts { get; init; } = new List<BookingDurationDiscount>();
    public int MaxOccupancy => Beds.Sum(x => x.MaximumOccupancy);
    public Facilities Facilities { get; } = new Facilities();

    public Room() 
    {
        AddDomainEvent(new HostRoomAddedDomainEvent());
    }
}
