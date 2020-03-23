using System.Collections.Generic;
using System.Threading.Tasks;
using Timor.Cms.Domains.Entities;
using Timor.Cms.IRepository;

namespace Timor.Cms.Repository.MongoDb
{
    public class MongoDbRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        public Task BatchDeleteAsync(List<TPrimaryKey> ids)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}