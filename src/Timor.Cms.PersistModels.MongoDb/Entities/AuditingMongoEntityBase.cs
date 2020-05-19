using System;
using MongoDB.Bson;
using Timor.Cms.PersistModels.MongoDb.Users;

namespace Timor.Cms.PersistModels.MongoDb.Entities
{
    public abstract class AuditingMongoEntityBase : MongoEntityBase, ISoftDelete
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public ObjectId? CreateUserId { get; set; }

        /// <summary>
        /// 最后更改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后更改用户
        /// </summary>
        public ObjectId? LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public ObjectId? DeleteUserId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
