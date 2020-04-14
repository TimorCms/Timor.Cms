using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Timor.Cms.PersistModels.MongoDb.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class UpdateTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _repository;

        public UpdateTests()
        {
            _repository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldUpdateSuccess()
        {
            var article = Mapper.Map<Article>(ArticleBuilder.Build());

            await _repository.InsertAsync(article);

            article.Title = Guid.NewGuid().ToString();

            await _repository.UpdateAsync(article);

            var updatedArticle = await _repository.GetByIdAsync(article.Id);

            updatedArticle.Title.Should().Be(article.Title);
        }

        [Fact]
        public async Task ShouldUpdateFailedWhenEntityNull()
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _repository.UpdateAsync(null);
            });

            Assert.NotNull(exception.Message);
        }

        [Fact]
        public async Task ShouldUpdateFailedWhenEntityNotExists()
        {
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _repository.UpdateAsync(Mapper.Map<Article>(ArticleBuilder.Build()));
            });

            Assert.NotNull(exception.Message);
        }
    }
}
