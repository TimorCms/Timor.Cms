using System;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Entities;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles
{
    public static class SeoBuilder
    {
        public static Seo Build(Action<Seo> modifier = null)
        {
            var seo = new Seo
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Uri = "/part1/part2",
                KeyWords = "Cms 轻量级",
                Description = "这是一篇绝世好文"
            };

            AuditingEntityBuilder.PopulateAuditingInfo(seo);

            modifier?.Invoke(seo);

            return seo;
        }

        public static Seo BuildForArticle(Action<Seo> modifier = null)
        {
            return Build(modifier);
        }

        public static Seo BuildForTag(Action<Seo> modifier = null)
        {
            return Build(seo =>
            {

                seo.KeyWords = "Cms";
                seo.Description = $"关于{seo.KeyWords}的相关新闻";
            });
        }

        public static Seo BuildForTag(Tag tag, Action<Seo> modifier = null)
        {
            return Build(seo =>
            {

                seo.KeyWords = tag.Name;
                seo.Description = $"关于{tag.Name}的相关新闻";
            });
        }

        public static Seo BuildForCategory(Action<Seo> modifier = null)
        {
            return Build(seo =>
            {
                seo.KeyWords = "公司简介";
                seo.Description = $"关于{seo.KeyWords}的相关介绍";
            });
        }
    }
}
