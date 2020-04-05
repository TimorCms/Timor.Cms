using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Repository.MongoDb;

namespace Timor.Cms.Service.Attachments
{
    public class AttachmentService
    {
        private readonly IMongoDbRepository<Attachment> _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IMongoDbRepository<Attachment> attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// 检查附件数据是否存在
        /// </summary>
        /// <param name="id">附件Id</param>
        /// <returns></returns>
        public async Task<bool> CheckAttachmentExist(ObjectId id)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(id);

            return attachment != null;
        }
    }
}
