namespace Timor.Cms.Domains.Entities
{
    public interface ISoftDelete
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
