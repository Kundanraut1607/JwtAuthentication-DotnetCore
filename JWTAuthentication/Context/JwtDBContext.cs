using JWTAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Context
{
    public class JwtDBContext : DbContext
    {
        public JwtDBContext(DbContextOptions<JwtDBContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
