using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mgmt30toolset.Model;
using Microsoft.EntityFrameworkCore;

namespace Mgmt30toolset.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : ModelObject 
    {
        private ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet.Where(t => t.DateDeleted == null);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).Where(t => t.DateDeleted == null);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).Where(t => t.DateDeleted == null).FirstOrDefault<T>();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
