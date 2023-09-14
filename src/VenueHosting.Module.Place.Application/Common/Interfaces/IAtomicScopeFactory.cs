namespace VenueHosting.Module.Place.Application.Common.Interfaces;

public interface IAtomicScopeFactory
{
    IAtomicScope CreateScope();
}