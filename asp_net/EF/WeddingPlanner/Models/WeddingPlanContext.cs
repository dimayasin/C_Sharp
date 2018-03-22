using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlanContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPlanContext(DbContextOptions<WeddingPlanContext> options) : base(options)
        { }

        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<User> RSVPS { get; set; }
        public DbSet<Guest> Guests { get; set; }



    }
}
