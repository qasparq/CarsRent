using CarsRent.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsRent.Data
{
    public class CarsRentDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<RentalPlace> RentalPlaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress01;Database=CarRent;Trusted_Connection=true");
        }

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
                    RentalPlaceId = 1,
                    CarType = CarTypE.Standard,
                },
                new Car
                {
                    Id = 2,
                    Name = "BMW",
                    Combustion = 12.0f,
                    CarAvaible = 9,
                    RentalPlaceId = 3,
                    CarType = CarTypE.Premium,
                },
                new Car
                {
                    Id = 3,
                    Name = "Chevrolet",
                    Combustion = 5.0f,
                    CarAvaible = 1,
                    RentalPlaceId = 2,
                    CarType = CarTypE.Basic,
                },
                new Car
                {
                    Id = 4,
                    Name = "Polonez",
                    Combustion = 21.0f,
                    CarAvaible = 1,
                    RentalPlaceId = 1,
                    CarType = CarTypE.Medium,
                }
             ) ;
            modelBuilder.Entity<RentalPlace>().HasData(
               new RentalPlace
               {
                   Id = 1,
                   City = "Krakow",
                   BasePrice = 70
               },
               new RentalPlace
               {
                   Id = 2,
                   City = "Rzeszow",
                   BasePrice = 120
               },
               new RentalPlace
               {
                   Id = 3,
                   City = "Warszawa",
                   BasePrice = 100
               }
               );
        }
    }
}
