using CleanArchitectureApp.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
