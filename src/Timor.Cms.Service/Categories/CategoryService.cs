using Timor.Cms.Dto.Categories;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Infrastructure.Extensions;

namespace Timor.Cms.Service.Categories
{
    public class CategoryService : ITransient
    {
        public void CreateCategory(CreateCategoryInput input)
        {
            if (string.IsNullOrWhiteSpace(input.ParentCategoryId))
            {

            }
        }
    }
}
