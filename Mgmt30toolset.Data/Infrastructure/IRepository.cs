using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mgmt30toolset.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void SaveChanges();
    }
}
