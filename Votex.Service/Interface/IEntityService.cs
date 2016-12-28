using System.Collections.Generic;
using Votex.Model.Base;

namespace Votex.Service.Interface
{

    public interface IEntityService<T> : IService
       where T : BaseEntity
    {
        bool Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        bool Update(T entity);
    }
}
