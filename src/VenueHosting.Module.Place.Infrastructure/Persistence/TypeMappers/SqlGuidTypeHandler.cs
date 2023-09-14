using System.Data;
using Dapper;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.TypeMappers;

internal sealed class SqlGuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid guid)
    {
        parameter.Value = guid.ToString();
    }

    public override Guid Parse(object value)
    {
        return new Guid((string)value);
    }
}