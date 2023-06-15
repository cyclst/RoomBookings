using System.ComponentModel.DataAnnotations;
using RoomBookings.Common.Domain;
using RoomBookings.Rooms.Domain.ValueObjects;

namespace RoomBookings.Rooms.Domain;

public class Room : Entity, IAggregateRoot
{
    public IEnumerable<Booking> Bookings { get; }
    public Address Address { get; }
    public IEnumerable<Bed> Beds { get; }
    public int MinimumBookingDurationDays { get; }
    public int? MaximumBookingDurationDays { get; }
    public double DailyPrice { get; }
    public IEnumerable<BookingDurationDiscount> BookingDurationDiscounts { get; }
    public int MaxOccupancy { get; }
    public Facilities Facilities { get; }

    protected Room() { }

    public Room(Address address, IEnumerable<Bed> beds, int minimumBookingDurationDays, int? maximumBookingDurationDays, 
        double dailyPrice, IEnumerable<BookingDurationDiscount> bookingDurationDiscounts, Facilities facilities)
    {
        Address = address;
        Beds = beds;
        MinimumBookingDurationDays = minimumBookingDurationDays;
        MaximumBookingDurationDays = maximumBookingDurationDays;
        DailyPrice = dailyPrice;
        BookingDurationDiscounts = bookingDurationDiscounts;
        Facilities = facilities;


        MaxOccupancy = beds.Sum(x => x.MaximumOccupancy);
    }
}
