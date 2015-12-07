using PaGolok.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.DB_Entity
{
    public class Role : AuditableEntity<long>
    {
        public string Name { get; set; }
    }
}
