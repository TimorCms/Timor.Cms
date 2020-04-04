using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timor.Cms.Infrastructure.Configuration
{
    public class JwtOption
    {
        public string SecurityKey { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int ClockSkewSeconds { get; set; }
    }
}
