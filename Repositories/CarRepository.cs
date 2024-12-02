using CarRentalAPI.Data;
using CarRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.Include(c => c.Brand).Include(c => c.Model).ToListAsync();

        public async Task<Car?> GetByIdAsync(int id) => await _context.Cars.Include(c => c.Brand).Include(c => c.Model).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car?> UpdateAsync(int id, Car car)
        {
            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null) return null;

            existingCar.RegistrationNo = car.RegistrationNo;
            existingCar.BrandId = car.BrandId;
            existingCar.ModelId = car.ModelId;
            existingCar.EngineCapacity = car.EngineCapacity;
            existingCar.EngineNumber = car.EngineNumber;
            existingCar.ChasyNumber = car.ChasyNumber;
            existingCar.FuelType = car.FuelType;
            existingCar.YearOfManufacture = car.YearOfManufacture;

            await _context.SaveChangesAsync();
            return existingCar;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
