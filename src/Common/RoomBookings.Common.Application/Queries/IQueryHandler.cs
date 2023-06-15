using MediatR;

namespace RoomBookings.CommonQueries;

public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, QueryResult> where TQuery : IQuery
{
}

public interface IItemQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ItemQueryResult<TResponse>> where TQuery : IItemQuery<TResponse>
{
}

public interface IEnumerableItemQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, EnumerableItemQueryResult<TResponse>> where TQuery : IEnumerableItemQuery<TResponse>
{
}