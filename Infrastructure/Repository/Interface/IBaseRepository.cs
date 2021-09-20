using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IBaseRepository<T>
    {

        IQueryable<T> getQueryable();
        void Insert(T entity);
        void Update(T Entity);
        void Delete(T entity);
        T getById(long id);

        void InsertRange(List<T> entities);
        void DeleteRange(List<T> entities);
        
    }
}

