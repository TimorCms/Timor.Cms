using System.Threading.Tasks;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb.Repositories.Article;

namespace Timor.Cms.Service.Articles
{
    public class AttachmentService : ITransient
    {
        private readonly AttachmentRepository _attachmentRepository;

        public AttachmentService(AttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<bool> Exist(string domainId)
        {
            return await _attachmentRepository.Exist(domainId);
        }
    }
}