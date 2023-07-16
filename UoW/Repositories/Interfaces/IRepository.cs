namespace UoW.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IReadonlyRepository<TEntity> where TEntity : class
    {
        void Update(TEntity entity);
        void Add(TEntity item);
        void Remove(TEntity item);
    }
}
