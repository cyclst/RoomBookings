using AutoMapper;
using Microsoft.Extensions.Logging;
using RoomBookings.Common.Application.Commands;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Domain;

namespace RoomBookings.Rooms.Application.Commands.AddHostRoom;

public class AddHostRoomCommandHandler : ICommandHandler<AddHostRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public AddHostRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper, ILogger<AddHostRoomCommandHandler> logger)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CommandResult<int>> Handle(AddHostRoomCommand command, CancellationToken cancellationToken)
    {
        var room = _mapper.Map<Room>(command);

        var id = await _roomRepository.AddAsync(room);

        return CommandResult.Ok(id);
    }
}
