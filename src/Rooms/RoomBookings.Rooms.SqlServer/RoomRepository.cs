using Microsoft.EntityFrameworkCore;
using RoomBookings.Common.Application.Persistence;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.SqlServer;

public class RoomRepository : IRoomRepository
{
    protected RoomsDbContext Context;

    //public IUnitOfWork UnitOfWork => Context;

    public RoomRepository(RoomsDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await Context.Rooms.FindAsync(id);
    }

    public IQueryable<Room> Query()
    {
        return Context.Rooms.AsQueryable();
    }

    public async Task<int> AddAsync(Room room)
    {
        await Context.Rooms.AddAsync(room);

        return room.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var room = await GetByIdAsync(id);

        if (room is null)
            return;

        if (Context.Entry(room).State == EntityState.Detached)
        {
            Context.Rooms.Attach(room);
        }

        Context.Rooms.Remove(room);
    }

    public void Update(Room room)
    {
        Context.Rooms.Attach(room);
        Context.Entry(room).State = EntityState.Modified;
    }
}
