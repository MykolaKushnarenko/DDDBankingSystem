using VenueHosting.Domain.Common.DomainEvents;

namespace VenueHosting.Domain.Common.Models;

public abstract class Entity<TId> : IHasDomainEvents, IEquatable<Entity<TId>> where TId: notnull
{
    public TId Id { get; protected set; }

    private List<IDomainEvent>? _domainEvents;

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected Entity()
    {

    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Entity<TId> other)
    {
        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}