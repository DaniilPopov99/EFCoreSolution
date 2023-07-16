using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UoW.Interfaces
{
    public interface IUnitOfWork : IReadUnitOfWork
    {
        void SaveChanges(bool concurrencyCheck = false, Action commitCallback = null);

        ITransaction BeginTransaction();

        ITransaction BeginTransaction(IsolationLevel isolationLevel);

        ITransaction Transaction { get; }
    }
}
