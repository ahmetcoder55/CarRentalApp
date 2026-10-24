using CarRentalApp.Models;

namespace CarRentalApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any())
            {
                return;
            }

            var brands = new[] { "Toyota", "BMW", "Mercedes-Benz", "Renault", "Volkswagen", "Ford", "Hyundai", "Fiat", "Audi", "Honda" };
            var models = new Dictionary<string, string[]>
            {
                { "Toyota", new[] { "Corolla", "Camry", "RAV4", "Yaris" } },
                { "BMW", new[] { "320i", "520d", "X5", "1.16i" } },
                { "Mercedes-Benz", new[] { "C200", "E220", "A180", "GLA" } },
                { "Renault", new[] { "Clio", "Megane", "Captur", "Austral" } },
                { "Volkswagen", new[] { "Golf", "Passat", "Polo", "Tiguan" } },
                { "Ford", new[] { "Focus", "Fiesta", "Kuga", "Puma" } },
                { "Hyundai", new[] { "i20", "Elantra", "Tucson", "Bayon" } },
                { "Fiat", new[] { "Egea", "Panda", "Tipo", "500" } },
                { "Audi", new[] { "A3", "A4", "Q3", "A5" } },
                { "Honda", new[] { "Civic", "HR-V", "City", "CR-V" } }
            };

            var random = new Random();
            var cars = new List<Car>();

            for (int i = 1; i <= 200; i++)
            {
                string brand = brands[random.Next(brands.Length)];
                string model = models[brand][random.Next(models[brand].Length)];
                int year = random.Next(2015, 2026);
                decimal dailyPrice = random.Next(800, 4500);
                bool isAvailable = random.Next(0, 2) == 1;

                cars.Add(new Car
                {
                    Brand = brand,
                    Model = $"{model} - {i}",
                    Year = year,
                    DailyPrice = dailyPrice,
                    IsAvailable = isAvailable,
                    ImagePath = null // Burada doğrudan null atıyoruz
                });
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}
