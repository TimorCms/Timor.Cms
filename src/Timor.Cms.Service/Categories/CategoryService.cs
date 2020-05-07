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
        private readonly ArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public CategoryService(CategoryRepository categoryRepository, IMapper mapper, 
            ArticleRepository articleRepository)
        {
            _categoryRepository = categoryRepository;
            _articleRepository = articleRepository;
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

        public async Task UpdateCategory(string id, UpdateCategoryInput input)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null) throw new BusinessException("分类不存在！");

            _mapper.Map(input, category);

            if (!string.IsNullOrWhiteSpace(input.ParentCategoryId))
            {
                var parentCategory = await _categoryRepository.GetById(input.ParentCategoryId);

                category.ParentCategory = parentCategory ?? throw new BusinessException("父分类不存在！");
            }

            await _categoryRepository.Update(category);
        }

        public async Task DeleteCategory(string id)
        {
            if (!await _categoryRepository.Exist(id)) 
                throw new BusinessException("分类不存在！");

            if (await _categoryRepository.HasChild(id))
                throw new BusinessException("含有子分类，无法删除！");

            if (await _articleRepository.ExistsByCategoryId(id))
                throw new BusinessException("该分类下已存在文章，无法删除！");

            await _categoryRepository.DeleteById(id);
        }
    }
}
