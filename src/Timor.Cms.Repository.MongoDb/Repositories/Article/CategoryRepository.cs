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
    }
}