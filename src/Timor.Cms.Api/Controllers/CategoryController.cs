using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timor.Cms.Dto.Categories;
using Timor.Cms.Service.Categories;

namespace Timor.Cms.Api.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 新建分类
        /// </summary>
        /// <param name="input"></param>
        [HttpPost]
        public async Task InsertCategory([FromBody]CreateCategoryInput input)
        {
            await _categoryService.CreateCategory(input);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(string id, [FromBody] UpdateCategoryInput input)
        {   
            await _categoryService.UpdateCategory(id, input);
            return NoContent();
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">要删除的分类的 ObjectId。</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
