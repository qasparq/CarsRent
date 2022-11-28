using CarsRent.Data;
using CarsRent.Entities;

namespace CarsRent.Repository
{
    public class CarRepository : IGenericRepository<Car>
    {
        private CarsRentDbContext context;
        public CarRepository()
        {
            context = new CarsRentDbContext();
        }
        
        public CarRepository(CarsRentDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars.ToList(); 
        }

        public Car GetById(int carId)
        {
            return context.Cars.Find(carId);
        }

        public void Insert(Car car)
        {
            context.Cars.Add(car);
        }

        public void Update(Car car)
        {
            context.Cars.Update(car);
        }

        public void Delete(Car id)
        {
            context.Cars.Remove(id);
        }
    }
}
