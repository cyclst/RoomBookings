using MediatR;

namespace RoomBookings.Common.Application.Commands;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, CommandResult<TResponse>> where TCommand : ICommand<TResponse>
{
}

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : ICommand
{
}
