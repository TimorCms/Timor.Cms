using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.CreateArtile;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb;

namespace Timor.Cms.Service.Articles
{
    public class ArticleService : ITransient
    {
        private readonly  IMongoDbRepository<Article> _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IMongoDbRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleOutput> GetArticleById(ObjectId id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            return _mapper.Map<ArticleOutput>(article);
        }

        public async Task CreateArtice(ArticeInput artice)
        {
            var entity = _mapper.Map<Article>(artice);

            await _articleRepository.InsertAsync(entity);
        }
    }
}
