using PaGolok.Data.Configurations;
using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Configurations
{
    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Property(ur => ur.UserId).IsRequired();
            Property(ur => ur.RoleId).IsRequired();
        }
    }
}
