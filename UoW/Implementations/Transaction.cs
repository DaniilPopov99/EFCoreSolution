using Microsoft.EntityFrameworkCore.Storage;
using UoW.Interfaces;

namespace UoW.Implementations
{
    internal class Transaction : ITransaction
    {
        protected IDbContextTransaction DbContextTran;

        public IUnitOfWork UnitOfWork { get; protected set; }

        private bool _inactive;

        private bool _transactionReused;

        public Transaction(IDbContextTransaction dbContextTran, IUnitOfWork uow, bool transactionReused)
        {
            DbContextTran = dbContextTran;
            UnitOfWork = uow;
            _transactionReused = transactionReused;
        }

        public event Action TransactonComitted;

        public void Commit()
        {
            if (!_inactive)
            {
                _inactive = true;

                if (!_transactionReused)
                {
                    // если дочерняя транзакция сделала Rollback, текущей транзакции делать Commit нельзя
                    if (DbContextTran == null)
                        throw new Exception();

                    DbContextTran.Commit();

                    if (TransactonComitted != null)
                    {
                        TransactonComitted();
                    }
                }
            }
        }

        public void Rollback()
        {
            if (!_inactive)
            {
                _inactive = true;

                //ZombieCheck
                if (DbContextTran != null)
                {
                    DbContextTran.Rollback();
                }
            }
        }

        public void Dispose()
        {
            if (!_inactive)
            {
                _inactive = true;

                if (!_transactionReused)
                {
                    DbContextTran.Dispose();
                }
            }
        }
    }
}
