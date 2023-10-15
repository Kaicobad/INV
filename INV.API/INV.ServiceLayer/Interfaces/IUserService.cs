using INV.API.DTO;
using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        public void AddUser(UserModel user);
        public Task<IEnumerable<UserModel>> GetAllUser();
    }
}
