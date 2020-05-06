using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using MongoDB.Bson;
using Timor.Cms.PersistModels.MongoDb.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class DeleteMultipleTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _repository;

        public DeleteMultipleTests()
        {
            _repository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldDeleteSuccess()
        {
            var entity1 = Mapper.Map<Article>(ArticleBuilder.Build());

            var entity2 = Mapper.Map<Article>(ArticleBuilder.Build());

            await _repository.InsertAsync(entity1);
            await _repository.InsertAsync(entity2);


            var ids = new List<ObjectId> { entity1.Id, entity2.Id };

            await _repository.DeleteMultipleAsync(ids);

            var deletedEntity1 = await _repository.GetByIdAsync(entity1.Id);
            var deletedEntity2 = await _repository.GetByIdAsync(entity2.Id);

            deletedEntity1.Should().BeNull();
            deletedEntity2.Should().BeNull();
        }

        [Fact]
        public async Task ShouldDeleteSuccessWhenPartOfIdNotExist()
        {
            var entity = Mapper.Map<Article>(ArticleBuilder.Build());

            await _repository.InsertAsync(entity);

            var ids = new List<ObjectId> { entity.Id, ObjectId.GenerateNewId() };

            await _repository.DeleteMultipleAsync(ids);

            var deletedEntity = await _repository.GetByIdAsync(entity.Id);

            deletedEntity.Should().BeNull();
        }
    }
}
