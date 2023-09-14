using VenueHosting.Module.Place.Application;
using VenueHosting.Module.Place.Application.Common.Interfaces;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

internal class AtomicFactory : IAtomicScopeFactory
{
    private readonly IDbConnectionFactory _connectionFactory;

    public AtomicFactory(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IAtomicScope CreateScope()
    {
        return new AtomicScope(_connectionFactory.CreateConnection());
    }
}