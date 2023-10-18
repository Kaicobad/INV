using INV.DomainLayer.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.ServiceLayer.JwtService
{
    public interface IJwtTokenService
    {
        string GetJwtToken(UserDTO user);
    }
}
