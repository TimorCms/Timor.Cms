using System.ComponentModel.DataAnnotations;

namespace Timor.Cms.Api.ViewModels.Account
{
    public class LoginRequest
    {
        /// <summary>
        /// 用户名，必填
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码，必填
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
