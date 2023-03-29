namespace VenueHosting.Domain.Common.Models;

public abstract class AggregateRote<TId> : Entity<TId> where TId : notnull
{
    protected AggregateRote(TId id) : base(id)
    {
    }
}