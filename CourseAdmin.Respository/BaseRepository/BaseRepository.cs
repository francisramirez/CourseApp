using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.UnitOfWork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace CourseAdmin.Respository.BaseRepository
{
    public class BaseRepository<TEntity> : IUnitOfWork, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        private DbSet<TEntity> _entity;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            this._entity = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
        }

        public virtual async Task Add(params TEntity[] entities)
        {
            await _entity.AddRangeAsync(entities);

        }
        public virtual async Task<bool> Commit()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.AnyAsync(filter);
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.SingleOrDefaultAsync(filter);
        }
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _entity.Where(filter);
        }

        public async Task<TEntity> GetById(int value)
        {
            return await _entity.FindAsync(value);
        }

        public virtual void Remove(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public Task<bool> Rollback()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
