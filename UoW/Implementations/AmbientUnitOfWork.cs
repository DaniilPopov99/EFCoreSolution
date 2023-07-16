using UoW.Interfaces;

namespace UoW.Implementations
{
    internal class AmbientUnitOfWork : IAmbientUnitOfWork
    {
        private readonly AsyncLocal<Dictionary<Type, IUnitOfWork>> _currentUnitOfWorks = new AsyncLocal<Dictionary<Type, IUnitOfWork>>();

        public IUnitOfWork GetCurrentUnitOfWork<TContext>()
        {
            var unitOfWorks = _currentUnitOfWorks.Value;
            if (unitOfWorks != null && unitOfWorks.ContainsKey(typeof(TContext)))
            {
                return unitOfWorks[typeof(TContext)];
            }

            return null;
        }

        public void SetCurrentUnitOfWork<TContext>(IUnitOfWork unitOfWork)
        {
            var unitOfWorks = _currentUnitOfWorks.Value;
            if (unitOfWorks == null)
            {
                unitOfWorks = new Dictionary<Type, IUnitOfWork>();
                _currentUnitOfWorks.Value = unitOfWorks;
            }

            unitOfWorks[typeof(TContext)] = unitOfWork;
        }

        public void ClearCurrentUnitOfWork<TContext>()
        {
            var unitOfWorks = _currentUnitOfWorks.Value;
            if (unitOfWorks != null && unitOfWorks.ContainsKey(typeof(TContext)))
            {
                unitOfWorks.Remove(typeof(TContext));
            }
        }
    }
}
