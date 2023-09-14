using System.Data.Common;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

public interface ISqlServerAtomicScope
{
    DbConnection Connection { get; }

    DbTransaction Transaction { get; }
}