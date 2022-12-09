using CarsRent.Entities;

namespace CarsRent.Repository
{
    public interface IRentalPlaceRepository
    {
        RentalPlace GetRentalPlace(int idRentalPlace);
    }
}
