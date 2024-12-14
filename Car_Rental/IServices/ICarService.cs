using Car_Rental.DTOS.Car;
using Car_Rental.Entities;

namespace Car_Rental.IServices
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsForOwner(string ownerId);
        Task<List<Car>> GetAllCarsExceptOnwerCar(string ownerId);
        Task<Car> GetCarById(int carId);
        Task<Car> PostCar(CarDto carDto);
        Task<Car> UpdateCar(int carId, CarDto carDto);
        Task<bool> DeleteCar(int carId);
        Task<List<Car>> GetAll();
            
    }
}
