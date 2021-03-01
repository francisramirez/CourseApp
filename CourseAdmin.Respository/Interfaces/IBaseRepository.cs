using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace CourseAdmin.Respository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int value);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        Task Add(TEntity entity);
        Task Add(params TEntity[] entities);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<bool> Commit();
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);

       
    }
}
