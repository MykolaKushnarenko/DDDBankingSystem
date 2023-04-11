using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(){}

    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; private set; }

    public string Currency { get; private set; }

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