namespace VenueHosting.Domain.Common.Models;

public abstract class AggregateRote<TId, TIdType> : Entity<TId>
where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

    protected AggregateRote(TId id) : base(id)
    {
    }

    protected AggregateRote()
    {
    }
}