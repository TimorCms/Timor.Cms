using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timor.Cms.Dto.Articles.CreateArticle;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Service.Articles;

namespace Timor.Cms.Api.Controllers
{
    [Route("api/v1/articles")]
    public class ArticlesController : Controller
    {
        private readonly ArticleService _articleService;

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
           var result = await _articleService.GetArticleById(id);

            return result;
        }

        /// <summary>
        /// 创建文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody]CreateArticleInput input)
        {
           var id=  await _articleService.CreateArticle(input);

            return Created($"/api/v1/articles/{id}",null);
        }
    }
}
