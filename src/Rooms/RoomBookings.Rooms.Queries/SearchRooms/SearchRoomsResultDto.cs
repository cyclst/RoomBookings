using RoomBookings.Rooms.Domain.ValueObjects;

namespace RoomBookings.RoomsQueries.SearchRooms;

public record SearchRoomsResultDto
{
    public IEnumerable<Bed> Beds { get; set; }
}
