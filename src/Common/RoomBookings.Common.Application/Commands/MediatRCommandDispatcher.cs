using MediatR;

namespace RoomBookings.Common.Application.Commands
{
    public class MediatRCommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        public MediatRCommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult<TResult>> Dispatch<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommandResult> Dispatch(ICommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command);
        }
    }
}
