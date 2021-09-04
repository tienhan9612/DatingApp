using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce_App.Models.Infrastructure.Interface
{
     public interface IRepository<TContext, TEntity>
    where TContext : class
        where TEntity : class
    {
       
        /// <summary>
        /// Retrieve a single item by it's primary key or return null if not found
        /// </summary>
        /// <param name="primaryKey">Prmary key to find</param>
        /// <returns>T</returns>
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> whereCondition);

        /// <summary>
        /// Returns all the rows for type T
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Returns all the rows for type TEntity on basis of filter condition
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> whereCondition);
               
        
        /// <summary>
        /// Updates this entity in the database using it's primary key
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="userId">The user performing the update</param>
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
        Task Add(TEntity entity); 
        /// <summary>
        /// Deletes this entry fro the database
        /// ** WARNING - Most items should be marked inactive and Updated, not deleted
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <param name="userId">The user Id who deleted the entity</param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultOrderBy(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<TEntity, int>> orderBy, string direction);
        
        /// <summary>
        /// Does this item exist by it's primary key
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> whereCondition);
        Task<int> Count(Expression<Func<TEntity, bool>> whereCondition);

    }
}