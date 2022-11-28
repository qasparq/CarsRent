namespace CarsRent.Entities
{
    public class RentalPlace
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int BasePrice { get; set; }
        public List<Car> Car { get; set; }

    }
}
