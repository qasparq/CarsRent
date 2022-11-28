using CarsRent.Entities;

namespace CarsRent.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int carId);
        void Insert(T car);
        void Update(T car);
        void Delete(T carId);
    }
}
