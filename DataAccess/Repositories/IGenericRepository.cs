using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Add(T entity);

        T Delete(T entity);

        void Edit(T entity);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        //TODO check adhoc queries
        void Save();
    }
}