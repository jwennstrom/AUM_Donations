using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUM.Core.Data
{
    public interface IRepository<T> : IQueryable<T>
    {
        void Add(T entity);
        T Get(object id);
        void Remove(T entity);
    }
}
