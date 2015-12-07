using PaGolok.Data.Configurations;
using PaGolok.Entities.Base;
using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaGolok.Data.DBInitializer;

namespace PaGolok.Data
{
    public class PaGolokContext : DbContext
    {
        public PaGolokContext()
            : base("PaGolokContext")
        {
           
            Database.SetInitializer<PaGolokContext>(new PaGolokDBInitializer<PaGolokContext>());
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;

                    entity.IsActive = true;
                    entity.IsDeleted = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
