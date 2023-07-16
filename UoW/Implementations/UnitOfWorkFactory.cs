using Microsoft.EntityFrameworkCore;
using System.Data;
using UoW.Interfaces;

namespace UoW.Implementations
{
    public class UnitOfWorkFactory: UnitOfWorkFactoryBase, IUnitOfWorkFactory
    {
        public UnitOfWorkFactory(IAmbientUnitOfWork ambientUnitOfWork) : base(ambientUnitOfWork)
        {
        }

        public override IUnitOfWork Create<TContext>(TContext context, IsolationLevel isolationLevel, bool createProxy, bool untracked)
        {
            return Create(isolationLevel, context, createProxy, untracked);
        }

        public IUnitOfWork Create<TContext>(TContext context) where TContext : DbContext
        {
            var uow = Create(context, IsolationLevel.Unspecified, false, false);

            //Если вызов был в транзакции, то отключать отслеживание не нужно, так как контекст будет использован внешний
            if (!ContextInTransaction)
            {
            }

            return uow;
        }

        public IReadUnitOfWork CreateReadOnly<TContext>(TContext context) where TContext : DbContext
        {
            var uow = Create(context, IsolationLevel.Unspecified, false, false);

            //Если вызов был в транзакции, то отключать отслеживание не нужно, так как контекст будет использован внешний
            if (!ContextInTransaction)
            {
            }

            return uow;
        }

        public IReadUnitOfWork CreateUntracked<TContext>(TContext context) where TContext : DbContext
        {
            var uow = Create(context, IsolationLevel.Unspecified, false, true);

            //Если вызов был в транзакции, то отключать отслеживание не нужно, так как контекст будет использован внешний
            if (!ContextInTransaction)
            {
            }

            return uow;
        }
    }
}
