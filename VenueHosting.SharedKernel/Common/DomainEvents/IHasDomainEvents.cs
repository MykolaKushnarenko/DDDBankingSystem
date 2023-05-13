namespace VenueHosting.SharedKernel.Common.DomainEvents;

public interface IHasDomainEvents
{
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }

    public void ClearDomainEvents();
}