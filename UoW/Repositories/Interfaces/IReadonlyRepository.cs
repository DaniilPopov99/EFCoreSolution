namespace UoW.Repositories.Interfaces
{
    public interface IReadonlyRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
