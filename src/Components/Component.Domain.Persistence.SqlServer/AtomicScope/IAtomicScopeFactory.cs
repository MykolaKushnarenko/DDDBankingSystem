namespace Component.Persistence.SqlServer.AtomicScope;

public interface IAtomicScopeFactory
{
    IAtomicScope CreateAtomicScope();
}