using static CarsRent.Controllers.CalculatorController;
using static CarsRent.Data.CarRentDb;

namespace CarsRent.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Combustion { get; set; }
        public int CarAvaible { get; set; }
        public string Localization { get; set; } = string.Empty;
        public int BasePrice  { get; set; }
        public CarTypE CarType { get; set; }
    }
}
