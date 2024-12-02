using CarRentalAPI.Models;

namespace CarRentalAPI.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(int id);
        Task<Car> AddAsync(Car car);
        Task<Car?> UpdateAsync(int id, Car car);
        Task<bool> DeleteAsync(int id);
    }
}
