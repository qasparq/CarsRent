namespace CarsRent.Entities
{
    public class CarRentDetails
    {
        public Car car { get; set; }
        public string Location { get; set; }
        public float EndPrice { get; set; }
        public float FuelPrice { get; set; }
    }
}
