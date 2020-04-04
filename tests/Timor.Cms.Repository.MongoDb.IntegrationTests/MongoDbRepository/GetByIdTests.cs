using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class GetByIdTests : MongoDbRepositoryTestBase
    {
        [Fact]
        public async Task ShouldGetArticleSuccess()
        {
            var repository = IocManager.Resolve<IMongoDbRepository<Article>>();

            var article = ArticleBuilder.Build();

            await repository.InsertAsync(article);

            var searchedArticle = await repository.GetByIdAsync(article.Id);

            searchedArticle.Should().NotBeNull();
        }
    }
}
