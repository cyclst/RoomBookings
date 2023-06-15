using AutoMapper;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Application.Commands.AddHostRoom;

public class AddHostRoomMappings : Profile
{
    public AddHostRoomMappings()
    {
        CreateMap<AddHostRoomCommand, Room>();
    }
}
