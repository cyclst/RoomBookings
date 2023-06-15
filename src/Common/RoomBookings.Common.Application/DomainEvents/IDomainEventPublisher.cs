using RoomBookings.Common.Domain;

namespace RoomBookings.Common.Application.DomainEvents;

public interface IDomainEventPublisher
{
    Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent;
}
