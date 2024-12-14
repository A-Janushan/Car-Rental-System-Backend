using Car_Rental.Data;
using Car_Rental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories
{
    public class CarRepository :  ICarRepository
    {

        private readonly CarRentalContext _dbContext;

        public CarRepository(CarRentalContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Car>> GetAllCarsExceptOnwerCar(string ownerId)
        {
            return await _dbContext.Cars.Include(c => c.User).Where(c => c.OwnerId != ownerId).ToListAsync();
        }

        public async Task<List<Car>> GetAllCarsForOwner(string ownerId)
        {
            return await _dbContext.Cars.Include(c => c.User).Where(c => c.OwnerId == ownerId).ToListAsync();
        }

        public async Task<Car> GetCarById(int carId)
        {
            return await _dbContext.Cars.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == carId);
        }
        public async Task<Car> PostCar(Car car)
        {
            var data = await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Car> UpdateCar(Car car)
        {
             _dbContext.Cars.Update(car);
          await _dbContext.SaveChangesAsync();
            return car;
        }
        public async Task<bool> DeleteCar(Car car)
        {
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Car>> GetAll()
        {
            var data = await _dbContext.Cars.ToListAsync()?? [];
            return data;
        }
    }
}
