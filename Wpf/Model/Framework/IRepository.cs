using System.Collections.Generic;

namespace Model.Framework {
    public interface IRepository<T> {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}