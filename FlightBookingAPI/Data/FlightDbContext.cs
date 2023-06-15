using Microsoft.EntityFrameworkCore;

namespace FlightBookingAPI.Data
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }

        // DbSet for your FlightBooking model
        public DbSet<FlightBookingModel> FlightBookings { get; set; }
    }
}
