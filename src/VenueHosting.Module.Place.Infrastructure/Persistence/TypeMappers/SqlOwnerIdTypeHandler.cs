using System.Data;
using Dapper;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.TypeMappers;

internal sealed class SqlOwnerIdTypeHandler : SqlMapper.TypeHandler<OwnerId>
{
    public override void SetValue(IDbDataParameter parameter, OwnerId value)
    {
        parameter.Value = value.Value.ToString();
    }

    public override OwnerId Parse(object value)
    {
        Guid id = Guid.Parse((string)value);
        return OwnerId.Create(id);
    }
}