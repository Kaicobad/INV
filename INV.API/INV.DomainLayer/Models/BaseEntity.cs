using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.DomainLayer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool InActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
