using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeZone.DAL.Models;

namespace TimeZone.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SlideShow> Slides { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
