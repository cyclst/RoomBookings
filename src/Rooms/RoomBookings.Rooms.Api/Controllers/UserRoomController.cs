using Microsoft.AspNetCore.Mvc;
using RoomBookings.CommonQueries;
using RoomBookings.RoomsQueries.SearchRooms;

namespace RoomBookings.Rooms.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IQueryDispatcher queryDispatcher, ILogger<RoomController> logger)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _logger = logger;
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<SearchRoomsResultDto>>> Search()
        {
            var result = await _queryDispatcher.Dispatch(new SearchRoomsQuery());

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Items);
        }
    }
}