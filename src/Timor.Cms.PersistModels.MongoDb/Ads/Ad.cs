using Timor.Cms.PersistModels.MongoDb.Articles;

namespace Timor.Cms.PersistModels.MongoDb.Ads
{
    public class Ad
    {
        /// <summary>
        /// 广告内容
        /// </summary>
        public Attachment Attachment { get; set; }

        /// <summary>
        /// 优先级，当同一个位置有多个广告时，可以通过优先级来决定显示的顺序（例如轮播图）
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 广告展示的位置
        /// </summary>
        public AdLocation Location { get; set; }
    }
}
