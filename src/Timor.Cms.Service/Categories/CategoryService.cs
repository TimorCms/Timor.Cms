using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timor.Cms.Dto.Categories;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Service.Categories
{
    public class CategoryService : ITransient
    {
        public void InsertCategory(InsertCategoryInput input)
        {
            var name = input.Name;
        }
    }
}
