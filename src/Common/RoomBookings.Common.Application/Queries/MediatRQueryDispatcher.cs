using MediatR;

namespace RoomBookings.CommonQueries
{
    public class MediatRQueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public MediatRQueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<QueryResult> Dispatch(IQuery query, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(query);
        }

        public async Task<ItemQueryResult<TResult>> Dispatch<TResult>(IItemQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(query);
        }

        public async Task<EnumerableItemQueryResult<TResult>> Dispatch<TResult>(IEnumerableItemQuery<TResult> query, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(query);
        }
    }
}
