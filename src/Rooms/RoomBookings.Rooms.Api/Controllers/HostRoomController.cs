using Microsoft.AspNetCore.Mvc;
using RoomBookings.Common.AspNetCore;
using RoomBookings.Rooms.Application.Commands.AddRoom;

namespace RoomBookings.Rooms.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostRoomController : ApiControllerBase
    {
        private readonly ILogger<HostRoomController> _logger;

        public HostRoomController(ILogger<HostRoomController> logger)
        {
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddRoom(AddRoomCommand command)
        {
            try
            {
                return await Mediator.Send(command);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddHostRoomCommandHandler Error");

                return BadRequest("Error adding room");
            }
}
    }
}