using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb.Repositories.Article
{
    public class ArticleRepository : ITransient
    {
        private readonly IMongoDbRepository<PersistModels.MongoDb.Articles.Article> _articleRepository;
        private readonly IMapper _mapper;

        public ArticleRepository(IMongoDbRepository<PersistModels.MongoDb.Articles.Article> articleRepository,
            IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<string> Insert(Domains.Articles.Article articleDomain)
        {
            var article = _mapper.Map<PersistModels.MongoDb.Articles.Article>(articleDomain);

             await _articleRepository.InsertAsync(article);

             return article.Id.ToString();
        }

        public async Task<Domains.Articles.Article> GetById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            var article = await _articleRepository.GetByIdAsync(id);

            var articleDomain = _mapper.Map<Domains.Articles.Article>(article);

            return articleDomain;
        }

        public Task<bool> ExistsByCategoryId(string categoryId)
        {
            var categoryObjectId =_mapper.Map<ObjectId>(categoryId);
            return _articleRepository.ExistsAsync(
                x => x.CategoryIds.Any(
                    x => x == categoryObjectId));
        }
    }
}