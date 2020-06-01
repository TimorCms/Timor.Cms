using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timor.Cms.Dto.Articles.CreateArticle;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Dto.Articles.UpdateArticle;
using Timor.Cms.Dto.Articles.SearchArticles;
using Timor.Cms.Dto.BaseDto;
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
        /// 根据特定条件查询DTO
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedOutput<SearchArticlesDto>> SearchArticles([FromQuery]SearchArticlesInput input)
        {
            return null;
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
            var id = await _articleService.CreateArticle(input);

            return Created($"/api/v1/articles/{id}",null);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id">文章 ID</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            await _articleService.DeleteArticle(id);

            return NoContent();
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <param name="input">更新文章请求</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(string id, [FromBody] UpdateArticleInput input)
        {
            await _articleService.UpdateArticle(id, input);

            return NoContent();
        }
    }
}
