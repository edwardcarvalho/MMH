using MMH.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMH.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public virtual bool Add(T entity)
        {
            if (entity == null) return false;

            try
            {
                using (var ctx = MMHContext.Create())
                {
                    ctx.Set<T>().Add(entity);
                    return ctx.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                //TODO: log exception
                throw new Exception(ex.ToString());
            }
        }

        public virtual bool Update(T entity)
        {
            if (entity == null) return false;

            try
            {
                using (var ctx = MMHContext.Create())
                {
                    ctx.Entry(entity).State = EntityState.Modified;
                    return ctx.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                //TODO: log exception
                throw new Exception(ex.ToString());
            }
        }

        public virtual bool Delete(T entity)
        {
            if (entity == null) return false;

            try
            {
                using (var ctx = MMHContext.Create())
                {
                    ctx.Set<T>().Remove(entity);
                    return ctx.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                //TODO: log exception
                throw new Exception(ex.ToString());
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                using (var ctx = MMHContext.Create())
                {
                    IQueryable<T> query = ctx.Set<T>();
                    return query;
                }
            }
            catch (Exception ex)
            {
                //TODO:Logar exception
                throw new Exception(ex.ToString());
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                using (var ctx = MMHContext.Create())
                {
                    IQueryable<T> query = ctx.Set<T>().Where(predicate);
                    return query;
                }
            }
            catch (Exception ex)
            {
                //TODO:Logar exception
                throw new Exception(ex.ToString());
            }

        }
    }
}
