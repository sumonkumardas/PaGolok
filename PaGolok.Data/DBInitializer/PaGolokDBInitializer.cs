using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.DBInitializer
{
    public class PaGolokDBInitializer : DropCreateDatabaseAlways<PaGolokContext>
    {
        protected override void Seed(PaGolokContext context)
        {

            Role[] roles = GenerateRoles();

            foreach (Role role in roles)
                context.RoleSet.Add(role);
            // create roles

            // username: chsakell, password: homecinema
            context.UserSet.Add(
                new User()
                {
                    Email="chsakells.blog@gmail.com",
                    Username="chsakell",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                     IsDeleted = false,
                     IsActive = true,
                    CreatedBy ="0",
                     CreatedDate = DateTime.Now,
                     UpdatedBy=null,
                     UpdatedDate=DateTime.MinValue
                }
            );

            // // create user-admin for chsakell
            context.UserRoleSet.Add(
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1,  // chsakell
                    CreatedBy ="0",
                     CreatedDate = DateTime.Now,
                     UpdatedBy=null,
                     UpdatedDate=DateTime.MinValue
                }
            );

            base.Seed(context);
        }

        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin",
                    CreatedBy ="0",
                     CreatedDate = DateTime.Now,
                     UpdatedBy=null,
                     UpdatedDate=DateTime.MinValue
                }
            };

            return _roles;
        }
    }
}
