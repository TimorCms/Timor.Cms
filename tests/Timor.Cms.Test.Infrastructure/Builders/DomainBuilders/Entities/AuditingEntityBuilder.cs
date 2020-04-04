using System;
using MongoDB.Bson;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities
{
    public class AuditingEntityBuilder
    {
        public static void PopulateAuditingInfo(AuditingEntity entity, Action<AuditingEntity> modifier = null)
        {
            entity.Id = ObjectId.GenerateNewId();
            entity.CreateTime = DateTime.Now.AddMonths(2);
            entity.LastModifyTime = DateTime.Now.AddDays(7);
            entity.IsDelete = false;
        }
    }
}
