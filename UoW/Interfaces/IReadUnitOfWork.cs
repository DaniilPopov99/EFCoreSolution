using Microsoft.EntityFrameworkCore;

namespace UoW.Interfaces
{
    public interface IReadUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        bool Untracked { get; }
    }
}
