using PaGolok.Data.Repositories;
using PaGolok.Entities.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaGolok.Data.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}
