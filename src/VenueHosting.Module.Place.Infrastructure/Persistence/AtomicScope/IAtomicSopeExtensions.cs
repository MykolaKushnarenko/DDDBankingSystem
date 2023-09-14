using System.Data.Common;
using VenueHosting.Module.Place.Application;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

public static class AtomicScopeExtensions
{
    public static DbConnection ToSqlConnection(this IAtomicScope atomicScope)
    {
        if (atomicScope is ISqlServerAtomicScope scope)
        {
            return scope.Connection;
        }

        throw new ArgumentException();
    }

    public static DbTransaction ToSqlTransaction(this IAtomicScope atomicScope)
    {
        if (atomicScope is ISqlServerAtomicScope scope)
        {
            return scope.Transaction;
        }

        throw new ArgumentException();
    }
}