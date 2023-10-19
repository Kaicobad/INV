using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.ServiceLayer.JwtService
{
    public interface IJwtTokenService
    {
        string GetJwtToken(UserModel user, List<UserRole> Roles);
    }
}
