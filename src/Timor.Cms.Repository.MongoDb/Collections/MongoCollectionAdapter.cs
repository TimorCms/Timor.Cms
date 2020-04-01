using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Timor.Cms.Repository.MongoDb.Collections
{
    public class MongoCollectionAdapter<TDocument> : IMongoCollectionAdapter<TDocument>
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoCollectionAdapter(IMongoCollection<TDocument> collection)
        {
            _collection = collection;
        }

        public IFindFluent<TDocument, TDocument> Find(
            Expression<Func<TDocument, bool>> filter,
            FindOptions options = null)
        {
            return _collection.Find(filter, options);
        }

        public async Task InsertOneAsync(
            TDocument document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await _collection.InsertOneAsync(document, options, cancellationToken);
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(
            Expression<Func<TDocument, bool>> filter,
            TDocument replacement,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _collection.ReplaceOneAsync(filter, replacement, options, cancellationToken);
        }

        public Task<DeleteResult> DeleteOneAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _collection.DeleteOneAsync(filter, cancellationToken);
        }

        public Task<DeleteResult> DeleteManyAsync(
            FilterDefinition<TDocument> filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _collection.DeleteManyAsync(filter, cancellationToken);
        }
    }
}
