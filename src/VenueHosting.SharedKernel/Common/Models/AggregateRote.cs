using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.SharedKernel.Common.Models;

public abstract class AggregateRote<T> : Entity<T>, IAggregateRote where T : notnull
{
    protected AggregateRote(Id<T> id)
    {
        Id = id;
    }

    protected AggregateRote()
    {
    }
}

public interface IAggregateRote{}