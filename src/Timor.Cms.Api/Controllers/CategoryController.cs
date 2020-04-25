using System;
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
        public void InsertCategory([FromBody]CreateCategoryInput input)
        {
            if (ModelState.IsValid)
            {
                throw new ArgumentException("Validate error.");
            }

            _categoryService.CreateCategory(input);
        }
    }
}
