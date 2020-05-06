using System.Collections.Generic;
using System.Security.Claims;

namespace Timor.Cms.Dto.Accounts
{
    public class LoginOutput
    {
        public bool IsSuccess { get; set; }
        
        public string UserName { get; set; }
        
        public List<Claim> Claims { get; set; }
    }
}