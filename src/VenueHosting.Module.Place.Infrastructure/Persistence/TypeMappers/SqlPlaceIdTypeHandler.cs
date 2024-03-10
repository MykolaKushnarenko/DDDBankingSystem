using System.Data;
using Component.Domain.Models;
using Dapper;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.TypeMappers;

internal sealed class SqlPlaceIdTypeHandler : SqlMapper.TypeHandler<Id<Domain.Place.Place>>
{
    public override void SetValue(IDbDataParameter parameter, Id<Domain.Place.Place> value)
    {
        parameter.Value = value.Value.ToString();
    }

    public override Id<Domain.Place.Place> Parse(object value)
    {
        Guid id = Guid.Parse((string)value);
        return new Id<Domain.Place.Place>(id);
    }
}