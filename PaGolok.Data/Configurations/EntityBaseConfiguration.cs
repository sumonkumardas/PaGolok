using PaGolok.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IAuditableEntity
    {
        public EntityBaseConfiguration()
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.CreatedDate);
            Property(e => e.CreatedBy);
            Property(e => e.IsActive);
            Property(e => e.IsDeleted);
            Property(e => e.UpdatedBy);
            Property(e => e.UpdatedDate);
        }
    }
}
