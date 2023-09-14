using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace VenueHosting.Module.Place.Infrastructure.Persistence;

internal sealed class SqlServerConnectionFactory : IDbConnectionFactory
{
    private readonly DbContextOptions _contextOptions;

    public SqlServerConnectionFactory(DbContextOptions contextOptions)
    {
        _contextOptions = contextOptions;
    }

    public DbConnection CreateConnection()
        => new SqlConnection(_contextOptions.ConnectionString);
}