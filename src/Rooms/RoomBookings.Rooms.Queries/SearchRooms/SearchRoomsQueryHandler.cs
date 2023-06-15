using AutoMapper;
using RoomBookings.CommonQueries;
using RoomBookings.Rooms.SqlServer;

namespace RoomBookings.RoomsQueries.SearchRooms
{
    public class SearchRoomsQueryHandler : IEnumerableItemQueryHandler<SearchRoomsQuery, SearchRoomsResultDto>
    {
        private readonly RoomsDbContext _roomsDbContext;
        private readonly IMapper _mapper;

        public SearchRoomsQueryHandler(RoomsDbContext roomsDbContext, IMapper mapper)
        {
            _roomsDbContext = roomsDbContext;
            _mapper = mapper;
        }

        public async Task<EnumerableItemQueryResult<SearchRoomsResultDto>> Handle(SearchRoomsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roomsDbContext.Rooms
                    .Where(x => !x.Bookings.Any(b => b.StartDate > query.EndDate))
                    .Select(a => _mapper.Map<SearchRoomsResultDto>(a));

                return EnumerableItemQueryResult.Ok(result.AsEnumerable());
            }
            catch (Exception ex)
            {
                return EnumerableItemQueryResult<SearchRoomsResultDto>.Error("Error searching rooms");
            }
        }
    }
}
