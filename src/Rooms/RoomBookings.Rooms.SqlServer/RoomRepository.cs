using System.Linq.Expressions;
using Cyclst.CleanArchitecture.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.SqlServer;

public class RoomRepository : IRoomRepository
{
    protected RoomsDbContext Context;

    public IUnitOfWork UnitOfWork { get; }

    public RoomRepository(RoomsDbContext context, IUnitOfWork unitOfWork)
    {
        Context = context;
        UnitOfWork = unitOfWork;
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        return await Context.Rooms.FindAsync(id);
    }

    public IAsyncEnumerable<Room> GetAllAsync()
    {
        return Context.Rooms.AsAsyncEnumerable();
    }

    public async Task<bool> AllQueryAsync(Expression<Func<Room, bool>> predicate)
    {
        return await Context.Rooms.AsQueryable().AllAsync(predicate);
    }

    public async Task<bool> AnyQueryAsync(Expression<Func<Room, bool>> predicate)
    {
        return await Context.Rooms.AsQueryable().AnyAsync(predicate);
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
