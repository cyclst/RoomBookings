using RoomBookings.Common.Domain;
using MediatR;

namespace RoomBookings.Common.Application.DomainEvents;

public class MediatRDomainEventPublisher : IDomainEventPublisher
{
    private readonly IMediator _mediator;

    public MediatRDomainEventPublisher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IDomainEvent
    {
        await _mediator.Publish(new MediatRDomainEvent<TEvent>(@event), cancellationToken);
    }
}
