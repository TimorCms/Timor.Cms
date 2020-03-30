using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.Moq;
using MongoDB.Driver;
using Moq;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class InsertArticleTests : MongoDbRepositoryTestBase
    {
        [Fact]
        public async Task ShouldInsertSuccess()
        {
            Mock<IMongoCollection<Article>> articleCollectionMock = new Mock<IMongoCollection<Article>>();

            Mock<IMongoCollectionProvider> collectionProvider = new Mock<IMongoCollectionProvider>();

            collectionProvider.Setup(p => p.GetCollection<Article>("article")).Returns(articleCollectionMock.Object);

            using var moq = AutoMock.GetLoose((builder) =>
            {
                RegistModule(builder);

                builder.Register(x => collectionProvider.Object).As<IMongoCollectionProvider>();
            });

            var repository = moq.Create<ArticleRepository>();

            var article = new Article();

            await repository.InsertAsync(article);

            // verify InsertOneAsync method have been called once times
            articleCollectionMock.Verify(c => c.InsertOneAsync(article, null, default), Times.Once());
        }

        [Fact]
        public async Task ShouldInsertFailedWhenArticleNull()
        {
            // Arrange
            var repository = IocManager.Resolve<ArticleRepository>();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
              {
                  // Action
                  await repository.InsertAsync(null);
              });

            // Assert
            Assert.NotNull(exception.Message);
        }
    }
}
