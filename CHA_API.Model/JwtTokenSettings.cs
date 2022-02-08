using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Model
{
    public class JwtTokenSettings
    {
        public string Authority { get; set; }

        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationInMinutes { get; set; }
    }
}
