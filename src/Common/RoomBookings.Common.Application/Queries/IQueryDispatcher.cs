namespace RoomBookings.CommonQueries;

public interface IQueryDispatcher
{
    public Task<QueryResult> Dispatch(IQuery query, CancellationToken cancellationToken = default);

    public Task<ItemQueryResult<TResult>> Dispatch<TResult>(IItemQuery<TResult> query, CancellationToken cancellationToken = default);

    public Task<EnumerableItemQueryResult<TResult>> Dispatch<TResult>(IEnumerableItemQuery<TResult> query, CancellationToken cancellationToken = default);
}