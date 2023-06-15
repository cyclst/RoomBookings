using AutoMapper;
using RoomBookings.Rooms.Domain.DomainEvent;

namespace RoomBookings.Rooms.Application.IntegrationEvents;

public class IntegrationEventMappings : Profile
{
    public IntegrationEventMappings()
    {
        CreateMap<RoomBookingCancelledDomainEvent, UserRoomBookingCancelledIntegrationEvent>();
        CreateMap<RoomBookingCreatedDomainEvent, UserRoomBookingCreatedIntegrationEvent>();
    }
}
