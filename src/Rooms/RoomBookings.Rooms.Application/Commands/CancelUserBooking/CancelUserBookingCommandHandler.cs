using RoomBookings.Rooms.Application.Command;
using MediatR;

namespace RoomBookings.Rooms.Application.Commands.AddUserBooking;

public class CancelUserBookingCommandHandler : IRequestHandler<CancelUserBookingCommand>
{
    IRoomRepository _roomRepository;

    public CancelUserBookingCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public Task Handle(CancelUserBookingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
