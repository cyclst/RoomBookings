using MediatR;

namespace RoomBookings.Common.Application.DomainEvents;

public class MediatRDomainEvent<TEvent> : INotification
{
    public TEvent Event { get; }

    public MediatRDomainEvent(TEvent @event)
    {
        Event = @event;
    }
}
