using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_ATM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet <Accounts> Accountses { get; set; }
        public DbSet <Transaction> Transactions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}