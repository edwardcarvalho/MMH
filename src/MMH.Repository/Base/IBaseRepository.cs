using System;
using System.Linq;
using System.Linq.Expressions;

namespace MMH.Repository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        bool Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}