using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.DomainLayer.Models
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
