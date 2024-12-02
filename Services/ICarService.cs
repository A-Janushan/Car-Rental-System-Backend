using CarRentalAPI.DTOs;
using CarRentalAPI.Helpers;

namespace CarRentalAPI.Services
{
    public interface ICarService
    {
        Task<ApiResponse<IEnumerable<CarDto>>> GetAllCarsAsync();
        Task<ApiResponse<CarDto>> GetCarByIdAsync(int id);
        Task<ApiResponse<CarDto>> AddCarAsync(CarDto carDto);
        Task<ApiResponse<CarDto>> UpdateCarAsync(int id, CarDto carDto);
        Task<ApiResponse<string>> DeleteCarAsync(int id);
    }
}
