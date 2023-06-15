using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RoomBookings.Common.Application.Commands;
using RoomBookings.CommonQueries;
using RoomBookings.Rooms.Application.Commands.AddHostRoom;

namespace RoomBookings.Rooms.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostRoomController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ILogger<HostRoomController> _logger;

        public HostRoomController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher, ILogger<HostRoomController> logger)
        {
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddHostRoom(AddHostRoomCommand command)
        {
            try
            {
                var result = await _commandDispatcher.Dispatch(command);

                if (!result.Success)
                    return BadRequest(result.ErrorMessage);

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddHostRoomCommandHandler Error");

                return BadRequest("Unknown error adding room");
            }
}
    }
}