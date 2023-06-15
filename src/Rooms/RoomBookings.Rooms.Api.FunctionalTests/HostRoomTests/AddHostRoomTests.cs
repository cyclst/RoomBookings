using System.Net.Http.Json;
using FluentAssertions;
using RoomBookings.Common.Domain.Constants;
using RoomBookings.Rooms.Application.Commands.AddHostRoom;
using RoomBookings.Rooms.Domain;
using RoomBookings.Rooms.Domain.Constants;
using RoomBookings.Rooms.Domain.ValueObjects;

namespace RoomBookings.Rooms.Api.FunctionalTests.HostRoomTests;

public class AddHostRoomTests : TestFixtureBase
{
    public AddHostRoomTests(TestApplicationFactory factory) : base(factory)
    { }

    [Fact]
    public async Task WhenAddRoom_GivenExistingHost_ThenRoomShouldBeAdded()
    {
        // Arrange

        var room = new AddHostRoomCommand
        {
            Address = new Address("1 No Way", "Some City", "Some Region", Country.UnitedKingdom, "SM1 1CT"),
            Beds = new List<Bed>
            {
                new Bed(BedType.Double),
                new Bed(BedType.Single)
            },
            DailyPrice = 100,
            Facilities = new Facilities
            {
                HasFreeWifi = true
            }
        };

        // Act

        var response = await Client.PostAsJsonAsync("hostroom/add", room);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        RoomRepository.Query().SingleOrDefault(x => x.Address.Address1 == "1 No Way").Should().NotBeNull();
    }
}
