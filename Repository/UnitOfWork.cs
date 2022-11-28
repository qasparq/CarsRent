using CarsRent.Data;

namespace CarsRent.Repository
{
    public class UnitOfWork
    {
        private CarsRentDbContext context;
        private CarRepository carRepository;
        private RentalPlaceRepository rentalPlaceRepository;

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

        public RentalPlaceRepository RentalPlaceRepository
        {
            get
            {
                if (rentalPlaceRepository == null)
                {
                    rentalPlaceRepository = new RentalPlaceRepository();
                }
                return rentalPlaceRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
