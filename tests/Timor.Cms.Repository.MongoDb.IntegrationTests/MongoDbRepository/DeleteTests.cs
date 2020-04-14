using System;
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
    public class DeleteTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _repository;

        public DeleteTests()
        {
            _repository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldDeleteSuccess()
        {
            var article = Mapper.Map<Article>(ArticleBuilder.Build());

            await _repository.InsertAsync(article);

            await _repository.DeleteAsync(article.Id);

            var deletedArticle = await _repository.GetByIdAsync(article.Id);

            deletedArticle.Should().BeNull();
        }

        [Fact]
        public async Task ShouldDeleteFailedWhenIdNotExist()
        {
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
             {
                 await _repository.DeleteAsync(ObjectId.GenerateNewId());
             });

            exception.Message.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldDeleteFailedWhenEntityIsNull()
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _repository.DeleteAsync((Article)null);
            });

            exception.Message.Should().NotBeNull();
        }
    }
}
