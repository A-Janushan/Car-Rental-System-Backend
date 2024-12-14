using Car_Rental.DTOS.Car;
using Car_Rental.Entities;
using Car_Rental.IServices;
using Car_Rental.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<Car>> GetAllCarsForOwner(string ownerId)
        {
            var data = await _carRepository.GetAllCarsForOwner(ownerId);
            return data;
        }

        public async Task<List<Car>> GetAllCarsExceptOnwerCar(string ownerId)
        {
            var data = await _carRepository.GetAllCarsExceptOnwerCar(ownerId);
            return data;
        }
        public async Task<Car> GetCarById(int carId)
        {
            var data = await _carRepository.GetCarById(carId);
            return data;
        }

        public async Task<Car> PostCar(CarDto carDto)
        {
            Car car = new Car()
            {
                Brand = carDto.Brand,
                Model = carDto.Modell,
                Year = carDto.Year,
                Color = carDto.Color,
                Seats = carDto.Seats,
                Cost_Per_Day = carDto.Cost_Per_Day,
                IsAvailable = carDto.IsAvailable,
                OwnerId = carDto.OwnerId,
            };
            
            var data = await _carRepository.PostCar(car);
            return data;
        }

        public async Task<Car> UpdateCar(int carId, CarDto carDto)
        {
            var getCar = await _carRepository.GetCarById(carId);
            var data = await _carRepository.UpdateCar(getCar);
            return data;
        }
        public async Task<bool> DeleteCar(int carId)
        {
            var getCar = await _carRepository.GetCarById(carId);
            var data = await _carRepository.DeleteCar(getCar);
            return data;
        }
        public async Task<List<Car>> GetAll()
        {
            var data = await _carRepository.GetAll();
            return data;
        }

    }
}
