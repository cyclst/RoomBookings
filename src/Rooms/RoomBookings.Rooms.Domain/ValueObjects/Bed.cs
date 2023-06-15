using RoomBookings.Common.Domain;
using RoomBookings.Rooms.Domain.Constants;

namespace RoomBookings.Rooms.Domain.ValueObjects;

public record Bed : ValueObject
{
    public BedType BedType { get; set; }

    public Bed(BedType bedType)
    {
        BedType = bedType;
    }

    public int MaximumOccupancy => GetMaximumOccupancy();

    private int GetMaximumOccupancy()
    {
        if (BedType == BedType.Double || BedType == BedType.Bunk)
            return 2;
        else
            return 1;
    }
}
