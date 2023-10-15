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
        Task<IEnumerable<RoleEntity>> GetAlRoles();
        Task<RoleEntity> Get(int id);
        void Insert(RoleEntity roles);
        void Update(RoleEntity roles);
        void Delete(RoleEntity roles);
    }
}
