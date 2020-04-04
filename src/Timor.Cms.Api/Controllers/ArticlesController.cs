using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Service.Articles;

namespace Timor.Cms.Api.Controllers
{
    [Route("api/v1/articles")]
    public class ArticlesController : Controller
    {
        private ArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// 根据文章ID获取文章
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ArticleOutput> GetArticleById(string id)
        {
           var result = await _articleService.GetArticleById(ObjectId.Parse(id));

            return result;
        }
    }
}
