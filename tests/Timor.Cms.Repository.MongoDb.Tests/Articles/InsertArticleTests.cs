using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.Moq;
using Moq;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Collections;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class InsertArticleTests : MongoDbRepositoryTestBase
    {
        [Fact]
        public async Task ShouldInsertSuccess()
        {
            Mock<IMongoCollectionAdapter<Article>> articleCollectionMock = new Mock<IMongoCollectionAdapter<Article>>();

            Mock<IMongoCollectionProvider<Article>> collectionProvider = new Mock<IMongoCollectionProvider<Article>>();

            collectionProvider.Setup(p => p.GetCollection()).Returns(articleCollectionMock.Object);

            using var moq = AutoMock.GetLoose((builder) =>
            {
                RegistModule(builder);

                builder.Register(x => collectionProvider.Object).As<IMongoCollectionProvider<Article>>();
            });

            var repository = moq.Create<IMongoDbRepository<Article>>();

            var article = new Article();

            await repository.InsertAsync(article);

            // verify InsertOneAsync method have been called once times
            articleCollectionMock.Verify(c => c.InsertOneAsync(It.IsAny<Article>(), null, default), Times.Once);
        }

        [Fact]
        public async Task ShouldInsertFailedWhenArticleNull()
        {
            // Arrange
            var repository = IocManager.Resolve<IMongoDbRepository<Article>>();

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
