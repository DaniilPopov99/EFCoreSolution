using Microsoft.EntityFrameworkCore;
using UoW.Interfaces;
using UoW.Repositories.Interfaces;

namespace UoW.Repositories.Implementations
{
    internal class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly IAmbientUnitOfWork _ambientUnitOfWork;

        protected DbContext Context
        {
            get
            {
                return UnitOfWork.Context;
            }
        }

        private IUnitOfWork UnitOfWork
        {
            get
            {
                var unitOfWork = _ambientUnitOfWork.GetCurrentUnitOfWork<TContext>();
                if (unitOfWork == null)
                {
                    throw new Exception();
                }

                return unitOfWork;
            }
        }

        private DbSet<TEntity> DbSet
        {
            get 
            { 
                return Context.Set<TEntity>(); 
            }
        }

        public GenericRepository(IAmbientUnitOfWork ambientUnitOfWork)
        {
            _ambientUnitOfWork = ambientUnitOfWork;
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
