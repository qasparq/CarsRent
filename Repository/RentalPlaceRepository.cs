using CarsRent.Data;
using CarsRent.Entities;

namespace CarsRent.Repository
{
    public class RentalPlaceRepository : IGenericRepository<RentalPlace>, IRentalPlaceRepository
    {
        private CarsRentDbContext context;
        public RentalPlaceRepository()
        {
            context = new CarsRentDbContext();
        }

        public RentalPlaceRepository(CarsRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(RentalPlace rentalPlaceId)
        {
            context.RentalPlaces.Remove(rentalPlaceId);
        }

        public IEnumerable<RentalPlace> GetAll()
        {
            return context.RentalPlaces.ToList();
        }

        public RentalPlace GetById(int rentalPlaceId)
        {
            return context.RentalPlaces.Find(rentalPlaceId);
        }


        public void Insert(RentalPlace rentalPlace)
        {
            context.RentalPlaces.Add(rentalPlace);
        }

        public void Update(RentalPlace rentalPlace)
        {
            context.RentalPlaces.Update(rentalPlace);
        }
        public RentalPlace GetRentalPlace(int carId)
        {
            int carPlaceId = context.Cars.Where(x => x.Id == carId).FirstOrDefault().RentalPlaceId;
            return context.RentalPlaces.Where(x => x.Id == carPlaceId).FirstOrDefault();
        }
    }
}
