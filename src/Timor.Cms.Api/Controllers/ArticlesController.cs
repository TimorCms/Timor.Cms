using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Timor.Cms.Service.Articles;
using Timor.Cms.Service.Articles.Dtos.GetArticleById;

namespace Timor.Cms.Api.Controllers
{
    [Route("api/v1/articles")]
    public class ArticlesController : ControllerBase
    {
        private ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public async Task<ArticleOutput> GetArticleById(string id)
        {
           var result = await _articleService.GetArticleById(ObjectId.Parse(id));

            return result;
        }
    }
}
