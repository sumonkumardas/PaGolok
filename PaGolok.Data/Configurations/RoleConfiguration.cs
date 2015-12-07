using PaGolok.Data.Configurations;
using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(ur => ur.Name).IsRequired().HasMaxLength(50);
        }
    }
}
