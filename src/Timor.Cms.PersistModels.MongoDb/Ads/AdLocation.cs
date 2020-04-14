using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.PersistModels.MongoDb.Ads
{
    /// <summary>
    /// 广告显示的位置
    /// </summary>
    public class AdLocation : MongoEntityBase
    {
        /// <summary>
        /// 位置的唯一标识
        /// </summary>
        /// <remarks>
        /// 在开发过程时，可以通过广告位置来获得一组指定的广告内容
        /// </remarks>
        public string Key { get; set; }

        /// <summary>
        /// 显示名称Ï
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 单个广告还是多个
        /// </summary>
        public bool IsMulpitle { get; set; } = false;
    }
}
