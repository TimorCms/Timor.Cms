using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.CreateArticle;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Infrastructure.Exceptions;
using Timor.Cms.Infrastructure.Extensions;
using Timor.Cms.Repository.MongoDb.Repositories.Article;

namespace Timor.Cms.Service.Articles
{
    public class ArticleService : ITransient
    {
        private readonly ArticleRepository _articleRepository;
        private readonly AttachmentRepository _attachmentRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ArticleService(ArticleRepository articleRepository, IMapper mapper,
            AttachmentRepository attachmentRepository, CategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ArticleOutput> GetArticleById(string id)
        {
            var article = await _articleRepository.GetById(id);

            return _mapper.Map<ArticleOutput>(article);
        }

        public async Task CreateArticle(CreateArticleInput input)
        {
            var article = _mapper.Map<Article>(input);

            await CheckCoverImageExist(input);

            await CheckAttachmentExist(input);

            await CheckCategoryExist(input);

            SetPublishDate(article);

            await SetCategory(input, article);

            await _articleRepository.Insert(article);
        }

        private async Task SetCategory(CreateArticleInput input, Article article)
        {
            article.Categories = 
                (await Task.WhenAll(input.CategoryIds.Select(x => _categoryRepository.GetById(x)))).ToList();
        }

        private async Task CheckCategoryExist(CreateArticleInput input)
        {
            if (input.CategoryIds.IsNotNullOrEmpty())
            {
                foreach (var categoryId in input.CategoryIds)
                {
                    if (!await _categoryRepository.Exist(categoryId))
                    {
                        throw new BusinessException("分类信息不存在！", nameof(input.CategoryIds), categoryId);
                    }
                }
            }
        }

        private static void SetPublishDate(Article article)
        {
            if (article.IsPublished)
                article.PublishDate = DateTime.Now;
        }

        private async Task CheckAttachmentExist(CreateArticleInput input)
        {
            if (input.AttachmentIds.IsNotNullOrEmpty())
            {
                foreach (var attachmentId in input.AttachmentIds)
                {
                    if (await AttachmentExist(attachmentId))
                    {
                        throw new BusinessException("附件不存在！", nameof(input.AttachmentIds), attachmentId);
                    }
                }
            }
        }

        private async Task CheckCoverImageExist(CreateArticleInput input)
        {
            if (!string.IsNullOrWhiteSpace(input.CoverImage))
            {
                if (await AttachmentExist(input.CoverImage))
                {
                    throw new BusinessException("封面图片对应的附件不存在！", nameof(input.CoverImage), input.CoverImage);
                }
            }
        }

        private async Task<bool> AttachmentExist(string attachmentId)
        {
            return await _attachmentRepository.Exist(attachmentId);
        }
    }
}