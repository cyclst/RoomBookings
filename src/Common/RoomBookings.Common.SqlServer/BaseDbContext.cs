using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomBookings.Common.Application.DomainEvents;
using RoomBookings.Common.Application.Persistence;
using RoomBookings.Common.Domain;

namespace RoomBookings.Common.SqlServer;

public abstract class BaseDbContext : DbContext, IUnitOfWork
{
    private readonly IDomainEventPublisher _domainEventPublisher;
    private readonly IMapper _mapper;

    public BaseDbContext(IDomainEventPublisher domainEventPublisher, 
        //IMapper mapper,
        DbContextOptions options) : base(options)
    {
        _domainEventPublisher = domainEventPublisher ?? throw new ArgumentNullException(nameof(domainEventPublisher));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        await DispatchDomainEvents();

        var response = await base.SaveChangesAsync(cancellationToken);

        await DispatchIntegrationEventsAsync();

        ClearDomainEvents();

        return response;
    }

    private async Task DispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<Entity>()
            .Select(po => po.Entity)
            .Where(po => po.DomainEvents.Any());

        foreach (var entity in domainEventEntities)
        {
            foreach (var entityDomainEvent in entity.DomainEvents)
                await _domainEventPublisher.Publish(entityDomainEvent);
        }
    }

    private async Task DispatchIntegrationEventsAsync()
    {
        var domainEventEntities = ChangeTracker.Entries<Entity>()
            .Select(po => po.Entity)
            .Where(po => po.DomainEvents.Any());

        foreach (var entity in domainEventEntities)
        {
            foreach (var entityDomainEvent in entity.DomainEvents)
            {
                //var integrationEvent = _mapper.Map(entityDomainEvent);

                //if (integrationEvent != null)
                //{
                //    await _integrationEventPublisher.Publish(integrationEvent);
                //}
            }
        }
    }

    private void ClearDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<Entity>()
            .Select(po => po.Entity)
            .Where(po => po.DomainEvents.Any());

        foreach (var entity in domainEventEntities)
        {
            entity.ClearDomainEvents();
        }
    }
}