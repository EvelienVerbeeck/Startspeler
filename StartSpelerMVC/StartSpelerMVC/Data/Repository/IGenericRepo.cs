using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartSpelerMVC.Data.Repository
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Toevoegen(TEntity entity);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> voorwaarden = null,params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleOrDefault(Expression<Func<TEntity, bool>> voorwaarden = null,params Expression<Func<TEntity, object>>[] includes);
    }
}
