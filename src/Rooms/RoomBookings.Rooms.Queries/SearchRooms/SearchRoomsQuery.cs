using AutoMapper;
using RoomBookings.CommonQueries;
using RoomBookings.Rooms.SqlServer;

namespace RoomBookings.RoomsQueries.SearchRooms;

public record SearchRoomsQuery : IEnumerableItemQuery<SearchRoomsResultDto>
{
    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}