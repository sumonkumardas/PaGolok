using PaGolok.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.DB_Entity
{
    public class Error : AuditableEntity<long>
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
