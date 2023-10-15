using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.DomainLayer.DTOs.User
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Emial { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
