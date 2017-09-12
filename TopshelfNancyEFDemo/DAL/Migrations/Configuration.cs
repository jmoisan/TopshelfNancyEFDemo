namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.UserContext";
        }

        protected override void Seed(DAL.UserContext context)
        {
            context.Users.AddOrUpdate(
                new User { First = "Bill", Last = "Board", Email = "sjenkins@aol.com" },
                new User { First = "Filet", Last = "Minyon", Email = "fminyon@gmail.com" },
                new User { First = "Barry", Last = "Cade", Email = "bcade@gmail.com" },
                new User { First = "Anna", Last = "Conda", Email = "aconda@yahoo.com" },
                new User { First = "Chris", Last = "Coe", Email = "ccoe@gmail.com" },
                new User { First = "Dan", Last = "Druff", Email = "ddruff@aol.com" },
                new User { First = "Russell", Last = "Sprout", Email = "rsprout@gmail.com" },
                new User { First = "Tim", Last = "Burr", Email = "tburr@gmail.com" },
                new User { First = "Tish", Last = "Hughes", Email = "thughes@gmail.com" },
                new User { First = "Skip", Last = "Stone", Email = "sstone@gmail.com" }
                );
        }
    }
}
