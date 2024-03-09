using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.SharedKernel.Domain;

public class Id<TEntity> : ValueObject
{
    public Guid Value { get; private set; }

    public Id(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Id<TEntity> CreateUnique()
    {
        return new Id<TEntity>(Guid.NewGuid());
    }
}