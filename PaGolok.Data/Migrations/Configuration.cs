using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PaGolokContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            var dbMigrator = new DbMigrator(this);

            // This is required to detect changes.
            var pendingMigrationsExist = dbMigrator.GetPendingMigrations().Any();

            if (pendingMigrationsExist)
            {
                dbMigrator.Update();
            }
        }

        protected override void Seed(PaGolokContext context)
        {


            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: chsakell, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
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
            });

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1,  // chsakell
                    CreatedBy ="0",
                     CreatedDate = DateTime.Now,
                     UpdatedBy=null,
                     UpdatedDate=DateTime.MinValue
                }
            });
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
        /*private Rental[] GenerateRentals()
        {
            for (int i = 1; i <= 45; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Random r = new Random();
                    int customerId = r.Next(1, 99);
                    Rental _rental = new Rental()
                    {
                        CustomerId = 1,
                        StockId = 1,
                        Status = "Returned",
                        RentalDate = DateTime.Now.AddDays(j),
                        ReturnedDate = DateTime.Now.AddDays(j + 1)
                    };

                    _rentals.Add(_rental);
                }
            }

            //return _rentals.ToArray();
        }*/
    }
}
