using INV.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.ServiceLayer.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<UserRole>> GetAlRoles();
        Task<UserRole> Get(int id);
        void Insert(UserRole roles);
        void Update(UserRole roles);
        void Delete(UserRole roles);
    }
}
