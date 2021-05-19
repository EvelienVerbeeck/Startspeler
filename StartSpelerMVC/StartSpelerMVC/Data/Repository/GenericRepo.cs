using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartSpelerMVC.Data.Repository
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        protected StartSpelerContext context { get; }
        public GenericRepo(StartSpelerContext context)
        { this.context = context; }
        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Toevoegen(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> voorwaarden = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (includes!=null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden !=null)
            {
                query.Where(voorwaarden);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetSingleOrDefault(Expression<Func<TEntity, bool>> voorwaarden = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden != null)
            {
                query.Where(voorwaarden);
            }
            return await query.SingleOrDefaultAsync();
        }
    }
}
