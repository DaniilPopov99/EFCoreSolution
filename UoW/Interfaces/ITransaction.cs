namespace UoW.Interfaces
{
    public interface ITransaction : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        event Action TransactonComitted;

        void Commit();

        void Rollback();
    }
}
