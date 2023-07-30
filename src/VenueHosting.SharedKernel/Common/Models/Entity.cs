using VenueHosting.SharedKernel.BLSpecifications;
using VenueHosting.SharedKernel.Common.DomainEvents;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.SharedKernel.Common.Models;

public abstract class Entity<TId> : IHasDomainEvents, ISupportSpecification, IEquatable<Entity<TId>> where TId: notnull
{
    public TId Id { get; protected set; }

    private List<IIntegrationEvent>? _domainEvents;

    public IReadOnlyList<IIntegrationEvent>? DomainEvents => _domainEvents;

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

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    protected void AddDomainEvent(IIntegrationEvent eventItem)
    {
        _domainEvents ??= new List<IIntegrationEvent>();
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    protected void CheckRule(IBusinessRule rule)
    {
        rule.CheckIfSatisfied();
    }
}