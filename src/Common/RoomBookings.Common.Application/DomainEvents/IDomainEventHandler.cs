using MediatR;
using RoomBookings.Common.Domain;

namespace RoomBookings.Common.Application.DomainEvents;

public interface IDomainEventHandler<TEvent>: INotificationHandler<MediatRDomainEvent<TEvent>>
{
    Task Handle(TEvent domainEvent, CancellationToken cancellationToken);
}
