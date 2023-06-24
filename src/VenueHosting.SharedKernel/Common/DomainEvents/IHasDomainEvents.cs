namespace VenueHosting.SharedKernel.Common.DomainEvents;

public interface IHasDomainEvents
{
    public IReadOnlyList<IntegrationEvent> DomainEvents { get; }

    public void ClearDomainEvents();
}