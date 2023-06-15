using RoomBookings.Common.Application.Commands;
using RoomBookings.Rooms.Application.Commands.AddHostRoom;
using RoomBookings.Rooms.Application.Command;

namespace RoomBookings.Rooms.Application.Commands.AddUserBooking;

public class AddUserBookingCommandHandler : ICommandHandler<AddUserBookingCommand>
{
    IRoomRepository _roomRepository;

    public AddUserBookingCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public Task<CommandResult> Handle(AddUserBookingCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
