using PaGolok.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.DB_Entity
{
    public class User : AuditableEntity<long>
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
