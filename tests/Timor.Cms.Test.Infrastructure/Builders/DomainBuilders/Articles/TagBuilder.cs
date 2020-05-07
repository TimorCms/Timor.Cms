using System;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles
{
    public static class TagBuilder
    {
        public static Tag Build(Action<Tag> modifier = null)
        {
            var tag = new Tag
            {
                Name = "Cms",
                Seo = SeoBuilder.BuildForTag()
            };

            AuditingEntityBuilder.PopulateAuditingInfo(tag);

            modifier?.Invoke(tag);

            return tag;
        }
    }
}
