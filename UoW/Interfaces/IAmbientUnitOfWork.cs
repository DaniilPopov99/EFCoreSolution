namespace UoW.Interfaces
{
    public interface IAmbientUnitOfWork
    {
        IUnitOfWork GetCurrentUnitOfWork<TContext>();

        void SetCurrentUnitOfWork<TContext>(IUnitOfWork unitOfWork);

        void ClearCurrentUnitOfWork<TContext>();
    }
}
