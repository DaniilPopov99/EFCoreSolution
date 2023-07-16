using Microsoft.EntityFrameworkCore;
using System.Data;
using UoW.Interfaces;

namespace UoW.Implementations
{
    public class UnitOfWorkFactoryBase
    {
        private readonly IAmbientUnitOfWork _ambientUnitOfWork;

        private bool _contextInTransaction;

        public bool ContextInTransaction 
        { 
            get 
            { 
                return _contextInTransaction; 
            } 
        }

        public UnitOfWorkFactoryBase(IAmbientUnitOfWork ambientUnitOfWork)
        {
            _ambientUnitOfWork = ambientUnitOfWork;
        }

        /// <summary>
        /// Creates a new instance of <see cref="IUnitOfWork"/>.
        /// </summary>
        /// <returns>Instances of <see cref="UnitOfWork"/>.</returns>
        protected IUnitOfWork Create<TContext>(IsolationLevel isolationLevel, TContext context, bool createProxy, bool untracked) where TContext : DbContext
        {
            var unitOfWorkByContext = _ambientUnitOfWork.GetCurrentUnitOfWork<TContext>();

            _contextInTransaction = unitOfWorkByContext != null && unitOfWorkByContext.Transaction != null; // если уже открыта транзакция, переиспользуем контекст

            DbContext dbContext = context;

            if (_contextInTransaction)
            {
                dbContext = unitOfWorkByContext.Context;
            }

            IUnitOfWork uow = null;
            if (_contextInTransaction)
            {
                uow = new UnitOfWork(dbContext, true, unitOfWorkByContext.Transaction, unitOfWorkByContext.Untracked);
            }
            else
            {
                uow = new UnitOfWork(dbContext, false, isolationLevel, untracked);
            }

            _ambientUnitOfWork.SetCurrentUnitOfWork<TContext>(uow);

            return uow;
        }

        public virtual IUnitOfWork Create<TContext>(TContext context, IsolationLevel isolationLevel = IsolationLevel.Unspecified, bool createProxy = true, bool untracked = false) where TContext : DbContext
        {
            return Create(isolationLevel, context, createProxy, untracked);
        }
    }
}
