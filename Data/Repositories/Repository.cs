using Data.Context;
using Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SystemContext SystemContext;

        public Repository(SystemContext _context)
        {
            SystemContext = _context;
        }

        public void Add(T _entity)
        {
            SystemContext.Set<T>().Add(_entity);

            SystemContext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> _entities)
        {
            SystemContext.Set<T>().AddRange(_entities);

            SystemContext.SaveChanges();
        }

        public void Update(T _obj)
        {
            SystemContext.Entry(_obj).State = EntityState.Modified;
            SystemContext.SaveChanges();
        }

        public T Get<Type>(Type _id)
        {
            return SystemContext.Set<T>().Find(_id);
        }

        public IList<T> GetAll()
        {
            return SystemContext.Set<T>().ToList();
        }

        public void Remove<Type>(Type _id)
        {
            T entity = SystemContext.Set<T>().Find(_id);

            Remove(entity);

            SystemContext.SaveChanges();
        }

        public void Remove(T _entity)
        {
            SystemContext.Set<T>().Remove(_entity);

            SystemContext.SaveChanges();
        }

    }
}
