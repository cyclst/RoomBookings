using MediatR;

namespace RoomBookings.CommonQueries
{
    public interface IQuery : IRequest<QueryResult>
    {
    }

    public interface IItemQuery<T> : IRequest<ItemQueryResult<T>>
    {
    }

    public interface IEnumerableItemQuery<T> : IRequest<EnumerableItemQueryResult<T>>
    {
    }
}
