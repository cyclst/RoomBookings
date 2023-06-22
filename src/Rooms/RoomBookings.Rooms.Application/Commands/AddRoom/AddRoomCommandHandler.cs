using MediatR;
using Mapster;
using Microsoft.Extensions.Logging;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Application.Commands.AddRoom;

public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;
    private readonly ILogger _logger;

    public AddRoomCommandHandler(IRoomRepository roomRepository, ILogger<AddRoomCommandHandler> logger)
    {
        _roomRepository = roomRepository;
    }

    public async Task<int> Handle(AddRoomCommand command, CancellationToken cancellationToken)
    {
        var room = command.Adapt<Room>();

        await _roomRepository.AddAsync(room);

        await _roomRepository.UnitOfWork.SaveChangesAsync();

        return room.Id;
    }
}
