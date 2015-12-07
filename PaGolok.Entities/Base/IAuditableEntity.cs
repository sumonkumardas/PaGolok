using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Entities.Base
{

    public interface IAuditableEntity : IEntity<long>
    {
        
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }

        bool IsActive { get; set; }

        bool IsDeleted { get; set; }
    }
}
