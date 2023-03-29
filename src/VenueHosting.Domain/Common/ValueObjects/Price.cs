using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    
    public string Currency { get; }

    public static Price Create(decimal amount, string currency)
    {
        return new Price(amount, currency);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}