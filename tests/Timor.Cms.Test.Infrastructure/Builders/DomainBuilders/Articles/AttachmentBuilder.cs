using System;
using MongoDB.Bson;
using Timor.Cms.Domains.Articles;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles
{
    public static class AttachmentBuilder
    {
        public static Attachment Build(Action<Attachment> modifier = null)
        {
            var attachment = new Attachment
            {
                Id = ObjectId.GenerateNewId().ToString(),
                DisplayName = "Timor素颜照",
                OriginalFileName = "timor素颜照.png",
                Path = "https://avatars1.githubusercontent.com/u/62528215?s=200&v=4"
            };

            modifier?.Invoke(attachment);

            return attachment;
        }

        public static Attachment BuildDoc(Action<Attachment> modifier = null)
        {
            var attachment = new Attachment
            {
                Id = ObjectId.GenerateNewId().ToString(),
                DisplayName = "TimorCms使用文档",
                OriginalFileName = "TimorCms使用文档.doc",
                Path = "https://avatars1.githubusercontent.com/timor-cms.doc"
            };

            modifier?.Invoke(attachment);

            return attachment;
        }
    }
}
