using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ToDo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}