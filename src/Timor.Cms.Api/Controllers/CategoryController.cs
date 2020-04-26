using System;
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
    }
}
