using System;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class InsertTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _repository;

        public InsertTests()
        {
            _repository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldInsertSuccess()
        {
            var article = ArticleBuilder.Build();

            await _repository.InsertAsync(article);

            var insertedArticle = await _repository.GetByIdAsync(article.Id);

            insertedArticle.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldInsertFailedWhenEntityTaskNull()
        {
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Action
                await _repository.InsertAsync(null);
            });

            // Assert
            Assert.NotNull(exception.Message);
        }
    }
}
