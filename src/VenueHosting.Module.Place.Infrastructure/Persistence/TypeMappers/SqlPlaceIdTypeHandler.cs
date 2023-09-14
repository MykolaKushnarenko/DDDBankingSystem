using System.Data;
using Dapper;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.TypeMappers;

internal sealed class SqlPlaceIdTypeHandler : SqlMapper.TypeHandler<PlaceId>
{
    public override void SetValue(IDbDataParameter parameter, PlaceId value)
    {
        parameter.Value = value.Value.ToString();
    }

    public override PlaceId Parse(object value)
    {
        Guid id = Guid.Parse((string)value);
        return PlaceId.Create(id);
    }
}