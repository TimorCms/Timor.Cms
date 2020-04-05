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
        /// <param name="attachmentIds">附件Id</param>
        /// <returns></returns>
        public async Task<bool> CheckAttachmentExist(params ObjectId[] attachmentIds)
        {
            foreach (var attachmentId in attachmentIds)
            {
                var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
                if (attachment == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查附件数据是否存在
        /// </summary>
        /// <param name="attachmentIds">附件Id</param>
        /// <returns></returns>
        public async Task<bool> CheckAttachmentExist(IEnumerable<ObjectId> attachmentIds)
        {
            return await CheckAttachmentExist(attachmentIds.ToArray());
        }
    }
}
