using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Timor.Cms.Dto.Articles.SearchArticles;
using Timor.Cms.Dto.BaseDto;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Infrastructure.Extensions;

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

        public Task Update(Domains.Articles.Article articleDomain)
        {
            var article = _mapper.Map<PersistModels.MongoDb.Articles.Article>(articleDomain);

            return _articleRepository.UpdateAsync(article);
        }

        public async Task<Domains.Articles.Article> GetById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            var article = await _articleRepository.GetByIdAsync(id);

            var articleDomain = _mapper.Map<Domains.Articles.Article>(article);

            return articleDomain;
        }

        public Task Delete(string domainId)
            => _articleRepository.DeleteAsync(_mapper.Map<ObjectId>(domainId));

        public Task<bool> ExistsByCategoryId(string categoryId)
        {
            var categoryObjectId = _mapper.Map<ObjectId>(categoryId);
            return _articleRepository.ExistsAsync(
                x => x.CategoryIds.Any(
                    z => z == categoryObjectId));
        }

        public async Task<PagedOutput<Domains.Articles.Article>> SearchArticles(SearchArticlesInput input)
        {
            var filterBuilder = Builders<PersistModels.MongoDb.Articles.Article>.Filter;

            var filters = Builders<PersistModels.MongoDb.Articles.Article>.Filter.Empty;

            if (input.Title.IsNotNullOrEmpty())
            {
                filters = filters & filterBuilder.Where(x =>
                    x.Title.Contains(input.Title.Trim()));
            }

            if (input.Author.IsNotNullOrEmpty())
            {
                filters = filters & filterBuilder.Where(x => x.Author.Contains(input.Author.Trim()));
            }

            if (input.IsPublished.HasValue)
            {
                filters = filters & filterBuilder.Where(x => x.IsPublished == input.IsPublished.Value);
            }

            if (input.StartPublishDate.HasValue)
            {
                filters = filters & filterBuilder.Where(x =>
                    x.PublishDate.HasValue && x.PublishDate.Value >= input.StartPublishDate);
            }

            if (input.EndPublishDate.HasValue)
            {
                filters = filters & filterBuilder.Where(x =>
                    x.PublishDate.HasValue && x.PublishDate.Value <= input.EndPublishDate);
            }

            if (input.CategoryId.IsNotNullOrEmpty())
            {
                var categoryId = _mapper.Map<ObjectId>(input.CategoryId);

                filters = filters & filterBuilder.Where(x => x.CategoryIds.Contains(categoryId));
            }

            var result = _articleRepository.Find(filters);

            var totalCount= await result.CountDocumentsAsync();

            var items= await result.Skip(input.Skip).Limit(input.PageSize).ToListAsync();
            
            return new PagedOutput<Domains.Articles.Article>(_mapper.Map<List<Domains.Articles.Article>>(items),(int)totalCount);
        }
    }
}