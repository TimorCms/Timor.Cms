using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class InsertArticleTests
    {
        [Fact]
        public async Task ShouldInsertSuccess()
        {
            var repository = new ArticleRepository();

            var guid = Guid.NewGuid();

            await repository.InsertAsync(new Article
            {
                Title = guid.ToString("N")
            });

            var client = new MongoClient("mongodb://sa:123qwe@127.0.0.1:27017/admin");

            var dataBase = client.GetDatabase("TimorCms");

            var collection = dataBase.GetCollection<Article>("article");

            var article = collection.FindAsync(a => a.Title == guid.ToString("N"));

            Assert.NotNull(article);
        }

        [Fact]
        public async Task ShouldInsertFailedWhenArticleNull()
        {
            // Arrange
            var repository = new ArticleRepository();

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
