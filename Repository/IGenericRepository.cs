using CarsRent.Entities;

namespace CarsRent.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int objId);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T objId);
    }
}
