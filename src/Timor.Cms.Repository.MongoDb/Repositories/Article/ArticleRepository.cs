using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;

namespace Timor.Cms.Repository.MongoDb.Repositories.Article
{
    public class ArticleRepository
    {
        private readonly IMongoDbRepository<PersistModels.MongoDb.Articles.Article> _articleRepository;
        private readonly IMapper _mapper;

        public ArticleRepository(IMongoDbRepository<PersistModels.MongoDb.Articles.Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task Insert(Domains.Articles.Article articleDomain)
        {
            var article = _mapper.Map<PersistModels.MongoDb.Articles.Article>(articleDomain);

            await _articleRepository.InsertAsync(article);
        }

        public async Task<Domains.Articles.Article> GetById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            var article = await _articleRepository.GetByIdAsync(id);

            var articleDomain = _mapper.Map<Domains.Articles.Article>(article);

            return articleDomain;
        }
    }
}