using Cyclst.CleanArchitecture.Application.Persistence;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Application.Command;

public interface IRoomRepository : IRepository<Room>
{

}
