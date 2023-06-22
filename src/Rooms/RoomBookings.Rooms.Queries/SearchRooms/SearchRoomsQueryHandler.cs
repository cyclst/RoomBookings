using Cyclst.CleanArchitecture.EntityFramework;
using MediatR;
using RoomBookings.Rooms.SqlServer;
using Mapster;

namespace RoomBookings.RoomsQueries.SearchRooms
{
    public class SearchRoomsQueryHandler : IRequestHandler<SearchRoomsQuery, PaginatedList<SearchRoomsResultDto>>
    {
        private readonly RoomsDbContext _context;

        public SearchRoomsQueryHandler(RoomsDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<SearchRoomsResultDto>> Handle(SearchRoomsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rooms
                .Where(x => !x.Bookings.Any(b => b.StartDate > request.EndDate))
                .OrderBy(x => x.DailyPrice)
                .ProjectToType<SearchRoomsResultDto>()
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
