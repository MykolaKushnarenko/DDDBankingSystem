using VenueHosting.SharedKernel.BLSpecifications;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.SharedKernel.Common.Services;

public class DomainService
{
    protected readonly DomainEventCollector EventCollector;

    protected DomainService(DomainEventCollector eventCollector)
    {
        EventCollector = eventCollector;
    }

    protected void CheckRule(IBusinessRule rule)
    {
        rule.CheckIfSatisfied();
    }
}