using CarsRent.Data;

namespace CarsRent.Repository
{
    public class UnitOfWork
    {
        private CarsRentDbContext context;
        private CarRepository carRepository;
        private RentalPlaceRepository rentalPlaceRepository;
        private ReservationRepository reservationRepository;
        private EmailRepository emailRepository;
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
        
        public ReservationRepository ReservationRepository
        {
            get
            {
                if (reservationRepository == null)
                {
                    reservationRepository = new ReservationRepository();
                }
                return reservationRepository;
            }
        }

        public EmailRepository EmailRepository
        {
            get
            {
                if (emailRepository == null)
                {
                    emailRepository = new EmailRepository();
                }
                return emailRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
