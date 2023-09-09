using GenericRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Repositories.Implementations
{
    internal class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly DbContext _dbContext;

        protected DbContext Context
        {
            get
            {
                return _dbContext;
            }
        }

        private DbSet<TEntity> DbSet
        {
            get 
            { 
                return Context.Set<TEntity>(); 
            }
        }

        public GenericRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(TEntity item)
        {
            if (item == null)
            {
                return;
            }

            DbSet.Add(item);
        }

        public void Remove(TEntity item)
        {
            if (item == null)
            {
                return;
            }

            DbSet.Remove(item);
        }

        public async Task SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Dispose()
        {
        }
    }
}
