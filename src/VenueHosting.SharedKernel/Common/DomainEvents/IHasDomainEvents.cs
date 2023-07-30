namespace VenueHosting.SharedKernel.Common.DomainEvents;

public interface IHasDomainEvents
{
    public IReadOnlyList<IIntegrationEvent> DomainEvents { get; }

    public void ClearDomainEvents();
}