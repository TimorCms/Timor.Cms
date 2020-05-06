using System;
using MongoDB.Bson;
using Timor.Cms.Domains.Ads;

namespace Timor.Cms.Test.Infrastructure.Builders.DomainBuilders.Ads
{
    public static class AdLocationBuilder
    {
        public static AdLocation Build(Action<AdLocation> modifier = null)
        {
            var location = new AdLocation
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Key = "HomeSlider",
                DisplayName = "首页轮播图",
                IsMulpitle = true
            };

            modifier?.Invoke(location);

            return location;
        }
    }
}
