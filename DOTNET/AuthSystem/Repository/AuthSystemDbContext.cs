using AuthSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Repository
{
    public class AuthSystemDbContext : DbContext
    {


        public AuthSystemDbContext(DbContextOptions<AuthSystemDbContext> options) : base(options)
        { }

        //define tables

        public DbSet<Users> Users { get; set; }
    }
}

