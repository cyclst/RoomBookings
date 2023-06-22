using Cyclst.CleanArchitecture.Domain;
using RoomBookings.Rooms.Domain.Constants;

namespace RoomBookings.Rooms.Domain.ValueObjects;

public record Bed : ValueObject
{
    public BedType BedType { get; init; }

    public int MaximumOccupancy => GetMaximumOccupancy();

    private int GetMaximumOccupancy()
    {
        if (BedType == BedType.Double || BedType == BedType.Bunk)
            return 2;
        else
            return 1;
    }
}
