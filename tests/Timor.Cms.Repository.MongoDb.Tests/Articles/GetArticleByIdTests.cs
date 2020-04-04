using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.Moq;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Collections;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class GetArticleByIdTests : MongoDbRepositoryTestBase
    {
        [Fact]
        public async Task ShouldGetArticleSuccess()
        {
            Mock<IMongoCollectionAdapter<Article>> articleCollectionMock = new Mock<IMongoCollectionAdapter<Article>>();

            articleCollectionMock
                .Setup(c => c.Find(It.IsAny<Expression<Func<Article, bool>>>(), null))
                .Returns(new Mock<IFindFluent<Article, Article>>().Object);

            Mock<IMongoCollectionProvider<Article>> collectionProvider = new Mock<IMongoCollectionProvider<Article>>();

            collectionProvider
                .Setup(p => p.GetCollection())
                .Returns(articleCollectionMock.Object);

            using var moq = AutoMock.GetLoose((builder) =>
            {
                RegistModule(builder);

                builder.Register(x => collectionProvider.Object).As<IMongoCollectionProvider<Article>>();
            });

            var repository = moq.Create<IMongoDbRepository<Article>>();

            try
            {
                await repository.GetByIdAsync(ObjectId.GenerateNewId());
            }
            catch
            {
                // ignore null object exception, it's a mock object issue
            }

            articleCollectionMock.Verify(c => c.Find(It.IsAny<Expression<Func<Article, bool>>>(), null), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnNullWhenIdNotExist()
        {
            var repository = IocManager.Resolve<IMongoDbRepository<Article>>();

            var result = await repository.GetByIdAsync(ObjectId.GenerateNewId());

            Assert.Null(result);
        }
    }
}
