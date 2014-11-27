using System.Collections.Generic;

namespace BrentUniversity.Service.Base
{
    public interface IEntityService<T> : IService
        where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
