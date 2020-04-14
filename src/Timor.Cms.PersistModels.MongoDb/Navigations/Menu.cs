using System.Collections.Generic;
using Timor.Cms.PersistModels.MongoDb.Entities;

namespace Timor.Cms.PersistModels.MongoDb.Navigations
{
    public class Menu : AuditingMongoEntityBase
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 跳转链接
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public IList<Menu> SubMenus { get; set; }
    }
}
