using System;

namespace BrentUniversity.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Commit();
    }
}
