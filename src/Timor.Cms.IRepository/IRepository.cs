using System.Collections.Generic;
using System.Threading.Tasks;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.IRepository
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task InsertAsync(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(TEntity entity);
        Task BatchDeleteAsync(List<TPrimaryKey> ids);
    }
}
