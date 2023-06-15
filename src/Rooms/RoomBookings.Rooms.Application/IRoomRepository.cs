using System.Diagnostics;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Application.Command;

public interface IRoomRepository
{
    Task<Room> GetByIdAsync(int id);

    IQueryable<Room> Query();

    Task<int> AddAsync(Room room);

    Task DeleteAsync(int id);

    void Update(Room room);
}
