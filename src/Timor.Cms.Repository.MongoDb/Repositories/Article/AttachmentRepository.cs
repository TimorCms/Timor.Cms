using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Timor.Cms.Infrastructure.Dependency;

namespace Timor.Cms.Repository.MongoDb.Repositories.Article
{
    public class AttachmentRepository : ITransient
    {
        private readonly IMongoDbRepository<PersistModels.MongoDb.Articles.Attachment> _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentRepository(IMongoDbRepository<PersistModels.MongoDb.Articles.Attachment> attachmentRepository,
            IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public async Task Insert(Domains.Articles.Attachment attachmentDomain)
        {
            var attachment = _mapper.Map<PersistModels.MongoDb.Articles.Attachment>(attachmentDomain);

            await _attachmentRepository.InsertAsync(attachment);
        }

        public async Task<bool> Exist(string domainId)
        {
            var result = await GetById(domainId);

            return result != null;
        }

        public async Task<Domains.Articles.Attachment> GetById(string domainId)
        {
            var id = _mapper.Map<ObjectId>(domainId);

            var attachment = await _attachmentRepository.GetByIdAsync(id);

            var attachmentDomain = _mapper.Map<Domains.Articles.Attachment>(attachment);

            return attachmentDomain;
        }
    }
}