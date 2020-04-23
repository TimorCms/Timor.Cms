using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.CreateArticle;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb;
using Timor.Cms.Repository.MongoDb.Repositories.Article;

namespace Timor.Cms.Service.Articles
{
    public class ArticleService : ITransient
    {
        private ArticleRepository _articleRepository;
        private IMapper _mapper;

        public ArticleService(ArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleOutput> GetArticleById(string id)
        {
            var article = await _articleRepository.GetById(id);

            return _mapper.Map<ArticleOutput>(article);
        }

        public async Task CreateArticle(CreateArticleInput input)
        {
            var article = _mapper.Map<Article>(input);

            if (article.IsPublished)
                article.PublishDate = DateTime.Now;

            await _articleRepository.Insert(article);
        }
    }
}
