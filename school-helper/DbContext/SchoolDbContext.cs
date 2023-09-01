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

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassSchedule> ClassSchedules { get; set; }

    }
}
