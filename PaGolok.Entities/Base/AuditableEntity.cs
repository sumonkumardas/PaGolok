using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.Base
{

    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }


        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public new long Id { get; set; }
        
    }
}
