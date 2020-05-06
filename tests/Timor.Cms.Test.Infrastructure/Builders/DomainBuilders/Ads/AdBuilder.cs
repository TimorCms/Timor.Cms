using System;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Ads
{
    public static class AdBuilder
    {
        public static Ad Build(Action<Ad> modifier = null)
        {
            var ad = new Ad
            {
                Attachment = AttachmentBuilder.Build(),
                Location = AdLocationBuilder.Build()
            };

            modifier?.Invoke(ad);

            return ad;
        }
    }
}
