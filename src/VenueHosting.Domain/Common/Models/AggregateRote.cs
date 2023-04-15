namespace VenueHosting.Domain.Common.Models;

public abstract class AggregateRote<TId, TIdType> : Entity<TId>, IAggregateRote
where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

    protected AggregateRote(TId id)
    {
        Id = id;
    }

    protected AggregateRote()
    {
    }
}

public interface IAggregateRote{}