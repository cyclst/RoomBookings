using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using RoomBookings.Rooms.Application.Command;
using RoomBookings.Rooms.Application.Commands.AddRoom;
using RoomBookings.Rooms.Domain;
using RoomBookings.Rooms.Domain.Constants;
using RoomBookings.Rooms.Domain.ValueObjects;
using RoomBookings.Rooms.SqlServer;

namespace RoomBookings.Rooms.Api.FunctionalTests.HostRoomTests;

public class AddHostRoomTests : TestFixtureBase
{
    public AddHostRoomTests(TestApplicationFactory factory) : base(factory)
    { }

    [Fact]
    public async Task WhenAddRoom_GivenExistingHost_ThenRoomShouldBeAdded()
    {
        // Arrange

        var room = new AddRoomCommand
        {
            Address = new Address("1 No Way", "Some City", "Some Region", Country.UnitedKingdom, "SM1 1CT"),
            Beds = new List<Bed>
            {
                new Bed { BedType = BedType.Double },
                new Bed { BedType = BedType.Single }
            },
            DailyPrice = 100,
            Facilities = new Facilities
            {
                HasFreeWifi = true
            }
        };

        // Act

        var response = await Client.PostAsJsonAsync("hostroom/add", room);
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        int.Parse(content).Should().BeGreaterThan(0);

        using (var scope = Factory.Services.CreateScope())
        {
            var roomRepository = scope.ServiceProvider.GetRequiredService<IRoomRepository>();

            (await roomRepository.AnyQueryAsync(x => x.Address.Address1 == "1 No Way")).Should().BeTrue();
        }
    }
}
