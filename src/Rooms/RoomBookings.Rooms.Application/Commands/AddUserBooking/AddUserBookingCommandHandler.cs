using RoomBookings.Rooms.Application.Command;
using MediatR;

namespace RoomBookings.Rooms.Application.Commands.AddUserBooking;

public class AddUserBookingCommandHandler : IRequestHandler<AddUserBookingCommand>
{
    IRoomRepository _roomRepository;

    public AddUserBookingCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
    }

    public Task Handle(AddUserBookingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
