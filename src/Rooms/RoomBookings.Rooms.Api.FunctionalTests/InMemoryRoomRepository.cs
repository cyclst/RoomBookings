using RoomBookings.Common.Test;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Api.FunctionalTests;

public class InMemoryRoomRepository : InMemoryRepository<Room>, IRoomRepository
{

}