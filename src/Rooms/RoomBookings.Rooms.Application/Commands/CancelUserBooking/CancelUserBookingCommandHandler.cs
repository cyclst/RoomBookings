using RoomBookings.Common.Application.Commands;
using RoomBookings.Rooms.Application.Commands.AddHostRoom;
using RoomBookings.Rooms.Application.Command;

namespace RoomBookings.Rooms.Application.Commands.AddUserBooking;

public class CancelUserBookingCommandHandler : ICommandHandler<CancelUserBookingCommand>
{
    IRoomRepository _roomRepository;

    public CancelUserBookingCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public Task<CommandResult> Handle(CancelUserBookingCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
