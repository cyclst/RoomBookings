using Cyclst.CleanArchitecture.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using RoomBookings.Common.AspNetCore;
using RoomBookings.RoomsQueries.SearchRooms;

namespace RoomBookings.Rooms.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ApiControllerBase
    {
        private readonly ILogger<RoomController> _logger;

        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Search")]
        public async Task<ActionResult<PaginatedList<SearchRoomsResultDto>>> Search(SearchRoomsQuery query)
        {
            try
            {
                return await Mediator.Send(query);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Search Error");

                return BadRequest("Search Error");
            }
        }
    }
}