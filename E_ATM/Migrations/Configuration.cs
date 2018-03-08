using E_ATM.Models;

namespace E_ATM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_ATM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E_ATM.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Accountses.AddOrUpdate(
                p => p.CardNumber,
                new Accounts(){CardNumber = 1, PinNumber = 12, Balance = 500},
                 new Accounts(){CardNumber = 2, PinNumber = 123, Balance = 800},
                 new Accounts(){CardNumber = 3, PinNumber = 1234, Balance = 200}
                );
        }
    }
}
