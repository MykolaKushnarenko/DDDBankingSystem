namespace Component.Persistence.SqlServer.AtomicScope;

public interface IAtomicFactory
{
    IAtomicScope CreateAtomicScope();
}