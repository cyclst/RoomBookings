namespace RoomBookings.Common.Domain;

public abstract class Entity
{
    public int Id { get; internal set; }
    public DateTime Created { get; private set; } = DateTime.Now;

    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
