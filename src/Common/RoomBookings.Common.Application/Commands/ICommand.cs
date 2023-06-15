using MediatR;

namespace RoomBookings.Common.Application.Commands
{
    public interface ICommand : IRequest<CommandResult>
    {
    }

    public interface ICommand<T> : IRequest<CommandResult<T>>
    {
    }
}
