using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.DomainLayer.Models
{
    public class UserEntity :BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public int? UserId { get; set; }
        public int RoleId { get; set; }
    }
}
