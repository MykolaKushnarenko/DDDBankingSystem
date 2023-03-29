using VenueHosting.Domain.Common.Entities;
using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; private set; }
    
    public int NumRatings { get; private set; }

    public static AverageRating Create(double value = 0, int numRating = 0)
    {
        return new AverageRating(value, numRating);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRatings;
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }
    
    public void RemoveNewRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }
}