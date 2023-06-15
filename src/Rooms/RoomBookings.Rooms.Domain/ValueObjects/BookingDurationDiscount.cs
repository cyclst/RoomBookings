using RoomBookings.Common.Domain;
using RoomBookings.Rooms.Domain.Constants;

namespace RoomBookings.Rooms.Domain.ValueObjects;

public record BookingDurationDiscount : ValueObject
{
    public int DurationDays { get; init; }
    public int DiscountPercentage { get; init; }
}
