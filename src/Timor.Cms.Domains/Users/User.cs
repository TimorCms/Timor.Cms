using Timor.Cms.Domains.Entities;

namespace Timor.Cms.Domains.Users
{
    public class User : AuditingDomainEntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        
                
        /// <summary>
        /// 规范化后的UserName
        /// </summary>
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 密码的Hash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// 规范化后的邮件地址
        /// </summary>
        public string NormalizedEmail { get; set; }
        
        public void SetNormalizedNames()
        {
            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = Email?.ToUpperInvariant();
        }
    }
}
