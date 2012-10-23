using System;

namespace Model.Framework {
    public interface IRepository<T> {
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
    }
}