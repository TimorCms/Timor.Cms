using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Timor.Cms.Infrastructure.Sessions
{
    public class Session : ISession
    {
        private readonly HttpContext _context;

        public Session(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor.HttpContext;
        }

        public string UserId
        {
            get { return _context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value; }
        }
    }
}