using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using Timor.Cms.PersistModels.MongoDb.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.IntegrationTests.MongoDbRepository
{
    public class FindAllTests : MongoDbRepositoryTestBase
    {
        private readonly IMongoDbRepository<Article> _articleRepository;

        public FindAllTests()
        {
            _articleRepository = IocManager.Resolve<IMongoDbRepository<Article>>();
        }

        [Fact]
        public async Task ShouldAutoFilterDeletedArticle()
        {
            var article = Mapper.Map<Article>(ArticleBuilder.Build());

            article.IsDelete = true;

            await _articleRepository.InsertAsync(article);

            var findArticles = await _articleRepository.FindAllAsync(x => true);

            findArticles.Should().NotContain(x => x.Id == article.Id);
        }
    }
}