using System.Data.Entity;

namespace DAL
{
    public class UserContext : DbContext
    {
        public UserContext(): base()
        {
            Database.Initialize(true);
        }

        public DbSet<User> Users { get; set; }
    }
}