using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}
