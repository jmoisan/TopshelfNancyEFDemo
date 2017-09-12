using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class UserService
    {
        public static async Task AddUser(User user)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<User> GetUser(int id)
        {
            using (var db = new UserContext())
            {
                User user = await (from u in db.Users
                                   where u.Id == id
                                   select u).FirstOrDefaultAsync();
                return user;
            }
        }

        public static async Task<List<User>> ListUsers()
        {
            using (var db = new UserContext())
            {
                List<User> users = await (from u in db.Users
                                          select u).ToListAsync();
                return users;
            }
        }

        public static async Task DeleteUser(int id)
        {
            using (var db = new UserContext())
            {
                var userToDelete = new User() { Id = id };
                db.Users.Attach(userToDelete);
                db.Users.Remove(userToDelete);
                await db.SaveChangesAsync();
            }
        }
    }
}
