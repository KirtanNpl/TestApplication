using Infrastructure.Context;
using Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
   public class BaseRepository<T>:IBaseRepository<T> where T: class
    {

        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }


        public IQueryable<T> getQueryable()
        {
            return _context.Set<T>();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }


        public void Update(T Entity)
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T getById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public void InsertRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

    }
}
