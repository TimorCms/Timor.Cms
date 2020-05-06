using System;
using System.Collections.Generic;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Ads;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles
{
    public static class CategoryBuilder
    {
        public static Category Build(Action<Category> modifier = null)
        {
            var category = new Category
            {
                Name = "公司简介",
                Description = "公司基本情况",
                Priority = 1,
                ParentCategory = null,
                Ads = new List<Ad>
                {
                    AdBuilder.Build()
                },
                Seo = SeoBuilder.BuildForCategory()
            };

            AuditingEntityBuilder.PopulateAuditingInfo(category);

            modifier?.Invoke(category);

            return category;
        }
    }
}
