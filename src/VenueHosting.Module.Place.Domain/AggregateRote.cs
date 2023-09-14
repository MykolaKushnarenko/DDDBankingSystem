using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Place.Domain;

public abstract class AggregateRote<TId> : Entity<TId>, IAggregateRote
{
    public TId Id { get; protected set; }

    protected AggregateRote(TId id)
    {
        Id = id;
    }

    protected AggregateRote()
    {
    }
}

public interface IAggregateRote{}