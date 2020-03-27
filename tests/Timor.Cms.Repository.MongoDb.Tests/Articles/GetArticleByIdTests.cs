using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb.Articles;
using Xunit;

namespace Timor.Cms.Repository.MongoDb.Tests.Articles
{
    public class GetArticleByIdTests
    {
        [Fact]
        public async Task ShouldGetArticleSuccess()
        {
            var repository = new ArticleRepository();

            var article = new Article
            {
                Title = Guid.NewGuid().ToString()
            };

            await repository.InsertAsync(article);

            var result = await repository.GetById(article.Id);

            Assert.Equal(article.Title, result.Title);
        }

        [Fact]
        public async Task ShouldReturnNullWhenIdNotExist()
        {
            var repository = new ArticleRepository();

            var result = await repository.GetById(ObjectId.GenerateNewId());

            Assert.Null(result);
        }
    }
}
