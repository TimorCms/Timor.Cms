using System;
using System.Collections.Generic;
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

        public async Task<string> CreateArticle(CreateArticleInput input)
        {
            var article = _mapper.Map<Article>(input);

            await CheckCoverImageExist(input);

            await CheckAttachmentExist(input);

            article.Categories = await GetCategorys(input);

            SetPublishDate(article);

            var id= await _articleRepository.Insert(article);

           return id;            
        }

        private async Task<IList<Category>> GetCategorys(CreateArticleInput input)
        {
            if (input.CategoryIds.IsNotNullOrEmpty())
            {
                var categoryIds = input.CategoryIds.Distinct();

                var categorys = await _categoryRepository.GetById(categoryIds);

                if (categoryIds.Count() != categorys.Count)
                    throw new BusinessException("分类信息不存在！");

                return categorys;
            }
            else
            {
                return null;
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
            if (!await AttachmentExist(input.CoverImage))
            {
                throw new BusinessException("封面图片对应的附件不存在！", nameof(input.CoverImage), input.CoverImage);
            }
        }

        private async Task<bool> AttachmentExist(string attachmentId)
        {
            if (!string.IsNullOrWhiteSpace(attachmentId))
            {
                return await _attachmentRepository.Exist(attachmentId);
            }
            else
            {
                return true;
            }
        }
    }
}