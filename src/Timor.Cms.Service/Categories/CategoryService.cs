using System.Threading.Tasks;
using AutoMapper;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Categories;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Infrastructure.Exceptions;
using Timor.Cms.Repository.MongoDb.Repositories.Article;

namespace Timor.Cms.Service.Categories
{
    public class CategoryService : ITransient
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(CategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateCategory(CreateCategoryInput input)
        {
            var domain = _mapper.Map<Category>(input);

            if (!string.IsNullOrWhiteSpace(input.ParentCategoryId))
            {
                var parentCategory = await _categoryRepository.GetById(input.ParentCategoryId);

                if (parentCategory == null)
                {
                    throw new BusinessException("父分类不存在！");
                }

                domain.ParentCategory = parentCategory;
            }

            await _categoryRepository.Insert(domain);
        }

        public async Task UpdateCategory(string id, CreateCategoryInput input)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null) throw new BusinessException("分类不存在！");

            category.Name = input.Name;
            category.Description = input.Description;
            category.Priority = input.Priority;

            if (!string.IsNullOrWhiteSpace(input.ParentCategoryId))
            {
                var parentCategory = await _categoryRepository.GetById(input.ParentCategoryId);

                category.ParentCategory = parentCategory ?? throw new BusinessException("父分类不存在！");
            }

            await _categoryRepository.Update(category);
        }
    }
}
