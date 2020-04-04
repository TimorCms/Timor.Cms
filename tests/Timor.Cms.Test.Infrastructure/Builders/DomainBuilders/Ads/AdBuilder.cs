using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timor.Cms.Domains.Ads;
using Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Articles;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Ads
{
    public class AdBuilder
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
