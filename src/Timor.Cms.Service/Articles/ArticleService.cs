using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Dto.Articles.CreateArtile;
using Timor.Cms.Dto.Articles.GetArticleById;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb;
using Timor.Cms.Service.Attachments;

namespace Timor.Cms.Service.Articles
{
    public class ArticleService : ITransient
    {
        private readonly IMongoDbRepository<Article> _articleRepository;
        private readonly IMongoDbRepository<Attachment> _attachmentRepository;
        private readonly IMapper _mapper;
        private readonly AttachmentService _attachmentService;
        public ArticleService(AttachmentService attachmentService, IMongoDbRepository<Article> articleRepository, IMongoDbRepository<Attachment> attachmentRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public async Task<ArticleOutput> GetArticleById(ObjectId id)
        {
            var article = await _articleRepository.GetByIdAsync(id);

            return _mapper.Map<ArticleOutput>(article);
        }

        public async Task CreateArtice(ArticeInput artice)
        {
           var attachmentIds = artice.AttachmentIds;
            attachmentIds.Add(artice.ImageId);

            if (await _attachmentService.CheckAttachmentExist(attachmentIds))
            {
                return;
            }

            var entity = _mapper.Map<Article>(artice);

            await _articleRepository.InsertAsync(entity);
        }

    }
}
