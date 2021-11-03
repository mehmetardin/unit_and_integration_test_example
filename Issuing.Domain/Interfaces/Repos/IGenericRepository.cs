using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Issuing.Domain.Interfaces.Repos
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> ListAllAsync();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
