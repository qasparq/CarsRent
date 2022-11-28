using CarsRent.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsRent.Data
{
    public class CarsRentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress01;Database=CarRentDb;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public enum CarTypE
        {
            Basic = 10, Standard = 13, Medium = 16, Premium = 20
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Name = "Audi",
                    Combustion = 9.0f,
                    CarAvaible = 3,
                    Localization = "Rzeszów",
                    BasePrice = 90,
                    CarType = CarTypE.Standard,
                },
                new Car
                {
                    Id = 2,
                    Name = "BMW",
                    Combustion = 12.0f,
                    CarAvaible = 9,
                    Localization = "Warszawa",
                    BasePrice = 100,
                    CarType = CarTypE.Premium,
                },
                new Car
                {
                    Id = 3,
                    Name = "Chevrolet",
                    Combustion = 5.0f,
                    CarAvaible = 1,
                    Localization = "Tarnów",
                    BasePrice = 250,
                    CarType = CarTypE.Basic,
                },
                new Car
                {
                    Id = 4,
                    Name = "Polonez",
                    Combustion = 21.0f,
                    CarAvaible = 1,
                    Localization = "Kraków",
                    BasePrice = 10,
                    CarType = CarTypE.Medium,
                }
             ) ;
        }
    }
}
