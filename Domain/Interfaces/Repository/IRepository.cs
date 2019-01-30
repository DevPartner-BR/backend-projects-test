using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();

        T Get<Type>(Type _id);

        void Add(T _entity);

        void AddRange(IEnumerable<T> _entities);

        void Update(T _entity);

        void Remove<Type>(Type _id);

        void Remove(T _entity);
    }
}
