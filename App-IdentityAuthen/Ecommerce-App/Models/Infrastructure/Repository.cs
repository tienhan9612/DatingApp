using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce_App.Models.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TContext : DataContext
        where TEntity : class
    {
        private readonly DataContext _dbContext;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> whereCondition)
        {
            var dbResult = await _dbContext.Set<TEntity>().Where(whereCondition).FirstOrDefaultAsync();
            return dbResult;
        }
              
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await _dbContext.Set<TEntity>().Where(whereCondition).ToListAsync();
        }
        

       public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        //--------------Exra generic methods--------------------------------

        public async Task<TEntity> SingleOrDefaultOrderBy(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<TEntity, int>> orderBy, string direction)
        {
            if (direction == "ASC")
            {
                return await _dbContext.Set<TEntity>().Where(whereCondition).OrderBy(orderBy).FirstOrDefaultAsync();

            }
            else
            {
                return await _dbContext.Set<TEntity>().Where(whereCondition).OrderByDescending(orderBy).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> whereCondition)
        {
            return  await _dbContext.Set<TEntity>().AnyAsync(whereCondition);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> whereCondition)
        {
            return  await _dbContext.Set<TEntity>().Where(whereCondition).CountAsync();
        }
        
    }
}
