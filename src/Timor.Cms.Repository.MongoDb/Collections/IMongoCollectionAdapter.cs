using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Timor.Cms.Repository.MongoDb.Collections
{
    public interface IMongoCollectionAdapter<TDocument>
    {
        IFindFluent<TDocument, TDocument> Find(
            Expression<Func<TDocument, bool>> filter,
            FindOptions options = null);

        Task InsertOneAsync(
            TDocument document,
            InsertOneOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ReplaceOneResult> ReplaceOneAsync(
            Expression<Func<TDocument, bool>> filter,
            TDocument replacement,
            ReplaceOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<DeleteResult> DeleteOneAsync(
            Expression<Func<TDocument, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<DeleteResult> DeleteManyAsync(
            FilterDefinition<TDocument> filter,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}