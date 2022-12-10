using Fudee_v2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fudee_v2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Dish>? Dishes { get; set; }
        public DbSet<Opinion>? Opinions { get; set; }
        public DbSet<Restaurant>? Restaurants { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Address>()
                .HasOne(c => c.Restaurant).WithOne(t => t.Address);

            modelbuilder.Entity<Restaurant>()
                .HasOne(t => t.Address).WithOne(c => c.Restaurant);

            modelbuilder.Entity<AppUser>()
                .HasMany(e => e.Restaurants).WithOne(c => c.User);

            modelbuilder.Entity<Restaurant>()
              .HasOne(c => c.User).WithMany(e => e.Restaurants);

            modelbuilder.Entity<AppUser>()
                .HasMany(u => u.Opinions).WithOne(o => o.User);

            modelbuilder.Entity<Opinion>()
                .HasOne(o => o.User).WithMany(u => u.Opinions);

            modelbuilder.Entity<Category>()
                .HasMany(u => u.Restaurants).WithOne(t => t.Category);

            modelbuilder.Entity<Restaurant>()
                .HasOne(t => t.Category).WithMany(u => u.Restaurants);

            modelbuilder.Entity<Restaurant>().HasMany(t => t.Opinions).WithOne(o => o.Restaurant);

            modelbuilder.Entity<Opinion>().HasOne(o => o.Restaurant).WithMany(t => t.Opinions).OnDelete(DeleteBehavior.Restrict);

        }
    }
}