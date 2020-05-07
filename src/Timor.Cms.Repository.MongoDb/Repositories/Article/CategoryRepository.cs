using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb.Repositories.Article
{
    public class CategoryRepository : ITransient
    {
        private readonly IMongoDbRepository<PersistModels.MongoDb.Articles.Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryRepository(IMongoDbRepository<PersistModels.MongoDb.Articles.Category> categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Insert(Domains.Articles.Category categoryDomain)
        {
            var category = _mapper.Map<PersistModels.MongoDb.Articles.Category>(categoryDomain);
            
            await _categoryRepository.InsertAsync(category);
        }

        public async Task Update(Domains.Articles.Category categoryDomain)
        {
            var category = _mapper.Map<PersistModels.MongoDb.Articles.Category>(categoryDomain);
            
            await _categoryRepository.UpdateAsync(category);
        }

        public Task DeleteById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            return _categoryRepository.DeleteAsync(id);
        }

        public Task<bool> HasChild(string parentId)
            => _categoryRepository.ExistsAsync(x => x.ParentCategoryId == parentId);

        public async Task<bool> Exist(string domainId)
        {
            var result = await GetById(domainId);

            return result != null;
        }

        public async Task<Domains.Articles.Category> GetById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            var category = await _categoryRepository.GetByIdAsync(id);

            var categoryDomain = _mapper.Map<Domains.Articles.Category>(category);

            return categoryDomain;
        }

        public async Task<IList<Domains.Articles.Category>> GetById(IEnumerable<string> domainIds)
        {
            var ids = _mapper.Map<List<ObjectId>>(domainIds);
            var list = await _categoryRepository.FindAllAsync(x => ids.Contains(x.Id));
            return _mapper.Map<List<Domains.Articles.Category>>(list);
        }
    }
}