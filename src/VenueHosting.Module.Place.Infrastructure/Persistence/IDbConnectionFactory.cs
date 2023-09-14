using System.Data.Common;

namespace VenueHosting.Module.Place.Infrastructure.Persistence;

public interface IDbConnectionFactory
{
    DbConnection CreateConnection();
}