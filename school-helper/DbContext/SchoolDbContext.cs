using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using school_helper.Entities;

namespace school_helper.DbContext
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Class> Class { get; set; }

        public DbSet<Day> Days { get; set; }

    }
}
