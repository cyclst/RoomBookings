//using RoomBookings.Common.Domain;
//using MediatR;

//namespace RoomBookings.Common.Application.DomainEvents;

//public class MediatRDomainEventHandler<TDomainEvent> : INotificationHandler<MediatRDomainEvent<TDomainEvent>>
//    where TDomainEvent : IDomainEvent
//{
//    private readonly List<IDomainEventHandler<TDomainEvent>> _handlers;

//    public MediatRDomainEventHandler(IEnumerable<IDomainEventHandler<TDomainEvent>> handlers)
//    {
//        // Optionally, throw an exception if you want to ensure all your domain events have handlers
//        _handlers = handlers?.ToList() ?? throw new ArgumentNullException(nameof(handlers));
//        if (_handlers.Count == 0)
//            throw new ApplicationException("No event handler registered");

//        // Or not
//        //_handlers = handlers?.ToList() ?? new List<IDomainEventHandler<TDomainEvent>>();
//    }

//    public async Task Handle(MediatRDomainEvent<TDomainEvent> request, CancellationToken cancellationToken)
//    {
//        foreach (var handler in _handlers)
//        {
//            await handler.Handle(request.Event, cancellationToken);
//        }
//    }
//}
