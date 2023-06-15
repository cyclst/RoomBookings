using AutoMapper;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.RoomsQueries.SearchRooms;

internal class SearchRoomsMappings : Profile
{
    public SearchRoomsMappings()
    {
        CreateMap<Room, SearchRoomsResultDto>();
    }
}
