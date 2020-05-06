namespace Timor.Cms.Dto.Accounts
{
    public class LoginInput
    {
        /// <summary>
        /// 登录名，支持用户名、手机号码、电子邮箱号码
        /// </summary>
        public string LoginName { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}