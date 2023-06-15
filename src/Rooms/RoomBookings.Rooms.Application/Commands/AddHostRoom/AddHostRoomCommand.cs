using System.ComponentModel.DataAnnotations;
using RoomBookings.Common.Application.Commands;
using RoomBookings.Rooms.Domain.ValueObjects;

namespace RoomBookings.Rooms.Application.Commands.AddHostRoom;

public record AddHostRoomCommand : ICommand<int>
{
    public Address Address { get; init; }
    public IEnumerable<Bed> Beds { get; init; }
    public int MinimumBookingDurationDays { get; init; } = 1;
    public int? MaximumBookingDurationDays { get; init; }
    public double DailyPrice { get; init; }
    public IEnumerable<BookingDurationDiscount> BookingDurationDiscounts { get; init; } = new List<BookingDurationDiscount>();
    public Facilities Facilities { get; init; } = new Facilities();
}