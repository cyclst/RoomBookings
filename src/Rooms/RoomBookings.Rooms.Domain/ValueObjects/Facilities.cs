using RoomBookings.Common.Domain;

namespace RoomBookings.Rooms.Domain.ValueObjects;

public record Facilities : ValueObject
{
    public bool HasFreeWifi { get; init; }
    public bool HasFreeParking { get; init; }
    public bool HasAirCon { get; init; }
    public bool HasSatelliteTv { get; init; }
}
