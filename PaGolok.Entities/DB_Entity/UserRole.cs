using PaGolok.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.DB_Entity
{
    public class UserRole : AuditableEntity<long>
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
