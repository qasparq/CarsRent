using CarsRent.Data;

namespace CarsRent.Repository
{
    public class UnitOfWork
    {
        private CarsRentDbContext context;
        private CarRepository carRepository;

        public UnitOfWork(CarsRentDbContext _context)
        {
            context = _context;
        }

        public CarRepository CarRepository
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepository();
                }
                return carRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
