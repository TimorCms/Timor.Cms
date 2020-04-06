using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [HttpPost]
        public void InsertCategory([FromBody]InsertCategoryInput input)
        {
            if (ModelState.IsValid)
            {
                throw new ArgumentException("Validate error.");
            }

            _categoryService.InsertCategory(input);
        }
    }
}
