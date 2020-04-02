using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb;
using Timor.Cms.Service.Articles.Dtos.GetArticleById;

namespace Timor.Cms.Service.Articles
{
    public class ArticleService : ITransient
    {
        private IMongoDbRepository<Article> _articleRepository;
        private IMapper _mapper;

        public ArticleService(IMongoDbRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleOutput> GetArticleById(ObjectId id)
        {
            var article = await _articleRepository.GetById(id);

            return _mapper.Map<ArticleOutput>(article);
        }
    }
}
