using Cyclst.CleanArchitecture.EntityFramework;
using MediatR;

namespace RoomBookings.RoomsQueries.SearchRooms;

public record SearchRoomsQuery : IRequest<PaginatedList<SearchRoomsResultDto>>
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}