using Microsoft.EntityFrameworkCore;
using System.Data;
using UoW.Interfaces;

namespace UoW.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _disposed;

        private readonly bool _contextReused;
        private readonly bool _untracked = false;
        private readonly Action<IUnitOfWork> _disposeCallback;

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        public bool Untracked
        {
            get
            {
                return _untracked;
            }
        }

        public ITransaction Transaction { get; protected set; }

        public UnitOfWork(DbContext context, bool contextReused, ITransaction transaction, bool untracked)
            : this(context, contextReused, untracked)
        {
            Transaction = transaction;
        }

        public UnitOfWork(DbContext context, bool contextReused, IsolationLevel isolationLevel, bool untracked)
            : this(context, contextReused, untracked)
        {
            if (isolationLevel != IsolationLevel.Unspecified)
            {
                Transaction = BeginTransaction(isolationLevel);
            }
        }

        private UnitOfWork(DbContext context, bool contextReused, bool untracked)
        {
            _contextReused = contextReused;
            _context = context;
            _untracked = untracked;
        }

        #region Implementation of IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (Transaction != null && Transaction.UnitOfWork == this)
            {
                //Transaction.Commit();
                Transaction.Dispose();
            }

            Dispose(true);
        }

        /// <summary>
        /// Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_disposeCallback != null)
            {
                _disposeCallback(this);
            }

            if (!disposing) 
                return;

            if (_disposed) 
                return;

            if (!_contextReused)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            _disposed = true;
        }
        #endregion

        public void SaveChanges(bool concurrencyCheck = false, Action commitCallback = null)
        {
            //try -catch-throw, чтобы иметь доступ к коллекции ошибок валидации EntityFramework в debug
            try
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (concurrencyCheck)
                    {
                        throw;
                    }
                    //TODO
                    //RefreshAll(RefreshMode.ClientWins);
                    _context.SaveChanges();
                }
                // выполнение/сохранение обратного вызова лишь в случае успешного сохранения единицы работы
                if (commitCallback != null)
                {
                    if (Transaction != null)
                    {
                        Transaction.TransactonComitted += commitCallback;
                    }
                    else
                    {
                        commitCallback();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                //TODO
                //ExceptionHandling(ex);
                throw new DbUpdateException(ex?.Message);
            }
        }

        public ITransaction BeginTransaction()
        {
            var transactionIsReusing = true;

            if (_context.Database.CurrentTransaction == null)
            {
                _context.Database.BeginTransaction();

                transactionIsReusing = false;
            }

            Transaction = new Transaction(_context.Database.CurrentTransaction, this, transactionIsReusing);

            return Transaction;
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            var transactionIsReusing = true;

            if (_context.Database.CurrentTransaction == null)
            {
                _context.Database.BeginTransaction(isolationLevel);

                transactionIsReusing = false;
            }

            Transaction = new Transaction(_context.Database.CurrentTransaction, this, transactionIsReusing);

            return Transaction;
        }
    }
}
