using System.Data.Common;
using Dapper;
using VenueHosting.Module.Place.Application;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

public abstract class BaseContext
{
    protected async Task InternalExecuteAsync(string sql, object param, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        await connection.ExecuteAsync(sql, param, transaction);
    }

    protected async Task<T> InternalFetchAsync<T>(Func<DbConnection, DbTransaction, Task<T>> func, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        return await func(connection, transaction);
    }

    protected async Task<T> InternalExecuteScalarAsync<T>(string sql, object param, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        return await connection.ExecuteScalarAsync<T>(sql, param, transaction);
    }

    protected async Task<IEnumerable<T>> InternalFetchAsync<T>(string sql, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        return await connection.QueryAsync<T>(sql, transaction);
    }

    protected async Task<IEnumerable<T>> InternalFetchAsync<T>(string sql, object param, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        return await connection.QueryAsync<T>(sql,param, transaction);
    }

    protected async Task<T> InternalFetchFirstAsync<T>(string sql, object param, IAtomicScope atomicScope)
    {
        (DbConnection connection, DbTransaction transaction) = GetDbDependencies(atomicScope);

        return await connection.QueryFirstAsync<T>(sql, param, transaction);
    }

    private (DbConnection connection, DbTransaction transaction) GetDbDependencies(IAtomicScope atomicScope)
    {
        DbConnection connection = atomicScope.ToSqlConnection();
        DbTransaction transaction = atomicScope.ToSqlTransaction();

        return (connection, transaction);
    }
}