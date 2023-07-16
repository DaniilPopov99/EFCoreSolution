using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UoW.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create<TContext>(TContext context, IsolationLevel isolationLevel, bool createProxy, bool untracked) where TContext : DbContext;
        IUnitOfWork Create<TContext>(TContext context) where TContext : DbContext;
        IReadUnitOfWork CreateReadOnly<TContext>(TContext context) where TContext : DbContext;
        IReadUnitOfWork CreateUntracked<TContext>(TContext context) where TContext : DbContext;
    }
}
