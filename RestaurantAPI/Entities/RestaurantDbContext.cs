using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(eb =>
            {
                eb.Property(r => r.Name).IsRequired().HasMaxLength(25);
                eb.Property(r => r.ContactEmail).IsRequired(false);
                eb.Property(r => r.ContactNumber).IsRequired(false);
            });

            modelBuilder.Entity<Dish>(eb =>
            {
                eb.Property(d => d.Name).IsRequired();
                eb.Property(d => d.Description).IsRequired(false);
            });

            modelBuilder.Entity<Address>(eb =>
            {
                eb.Property(a => a.City).IsRequired().HasMaxLength(50);
                eb.Property(a => a.Street).IsRequired().HasMaxLength(50); 
            });
        }
    }
}