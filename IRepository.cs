using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WPFTestApp
{
    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
