using Car_Rental.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsForOwner(string ownerId);
        Task<List<Car>> GetAllCarsExceptOnwerCar(string ownerId);
        Task<Car> GetCarById(int carId);
        Task<Car> PostCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);
        Task<List<Car>> GetAll();
        
    }
}
