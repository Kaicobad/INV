using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.DomainLayer.DTOs.Common
{
    public class JwtCredentialsDTO
    {
        public string Key { get; set; } = "YourSecretKeyForAuthenticationOfApplication";
        public string Issuer { get; set; } = "youtCompanyIssuer.com";
    }
}
