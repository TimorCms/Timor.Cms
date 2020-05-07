using System;
using MongoDB.Bson;
using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities
{
    public static class AuditingEntityBuilder
    {
        public static void PopulateAuditingInfo(AuditingDomainEntityBase domainEntityBase, Action<AuditingDomainEntityBase> modifier = null)
        {
            domainEntityBase.Id = ObjectId.GenerateNewId().ToString();
            domainEntityBase.CreateTime = DateTime.Now.AddMonths(2);
            domainEntityBase.LastModifyTime = DateTime.Now.AddDays(7);
            domainEntityBase.IsDelete = false;
        }
    }
}
