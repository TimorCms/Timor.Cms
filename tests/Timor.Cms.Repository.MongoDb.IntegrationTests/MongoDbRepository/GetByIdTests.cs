using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using MongoDB.Bson;
using Timor.Cms.PersistModels.MongoDb.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class GetByIdTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _articleRepository;

        public GetByIdTests()
        {
            _articleRepository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldGetArticleSuccess()
        {
            var article = Mapper.Map<Article>(ArticleBuilder.Build());

            await _articleRepository.InsertAsync(article);

            var searchedArticle = await _articleRepository.GetByIdAsync(article.Id);

            searchedArticle.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullWhenIdNotExist()
        {
            var result = await _articleRepository.GetByIdAsync(ObjectId.GenerateNewId());

            Assert.Null(result);
        }
    }
}
