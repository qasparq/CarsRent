using CarsRent.Data;
using CarsRent.Entities;

namespace CarsRent.Repository
{
    public class ReservationRepository : IGenericRepository<Reservation>
    {
        private CarsRentDbContext context;
        public ReservationRepository()
        {
            context = new CarsRentDbContext();
        }

        public ReservationRepository(CarsRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(Reservation reservationId)
        {
            context.Reservations.Remove(reservationId);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }

        public Reservation GetById(int reservationId)
        {
            return context.Reservations.Find(reservationId);
        }

        public void Insert(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }

        public void Update(Reservation reservationId)
        {
            context.Reservations.Update(reservationId);
        }

        public Reservation GetByCarId(int carId)
        {
            return context.Reservations.Where(reservation => reservation.Car.Id == carId).FirstOrDefault();
        }
    }
}
