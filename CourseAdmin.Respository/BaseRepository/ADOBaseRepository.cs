
using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseAdmin.Respository.BaseRepository
{
    public class ADOBaseRepository<TEntity> : IUnitOfWork, IBaseRepository<TEntity> where TEntity : class
    {
        public Task Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Add(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int value)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Rollback()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
