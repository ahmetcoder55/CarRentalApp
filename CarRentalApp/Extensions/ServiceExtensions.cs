using CarRentalApp.Data;
using CarRentalApp.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddMaps(typeof(MappingProfile));
            });
        }
    }
}
