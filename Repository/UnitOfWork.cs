using CarsRent.Data;

namespace CarsRent.Repository
{
    public class UnitOfWork
    {
        private CarsRentDbContext context;
        private CarRepository carRepository;
        private RentalPlaceRepository rentalPlaceRepository;
        private ReservationRepository reservationRepository;

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
                    carRepository = new CarRepository(context);
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
                    rentalPlaceRepository = new RentalPlaceRepository(context);
                }
                return rentalPlaceRepository;
            }
        }

        public ReservationRepository ReservationRepository
        {
            get
            {
                if(reservationRepository == null)
                {
                    reservationRepository = new ReservationRepository(context);
                }
                return reservationRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
