using AutoMapper;
using CarRentalAPI.DTOs;
using CarRentalAPI.Helpers;
using CarRentalAPI.Models;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CarDto>>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            var carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);

            return new ApiResponse<IEnumerable<CarDto>>
            {
                Success = true,
                Payload = carDtos,
                Message = "Cars retrieved successfully."
            };
        }

        public async Task<ApiResponse<CarDto>> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return new ApiResponse<CarDto>
                {
                    Success = false,
                    Message = "Car not found.",
                    Errors = new List<string> { $"No car found with ID {id}." }
                };
            }

            var carDto = _mapper.Map<CarDto>(car);

            return new ApiResponse<CarDto>
            {
                Success = true,
                Payload = carDto,
                Message = "Car retrieved successfully."
            };
        }

        public async Task<ApiResponse<CarDto>> AddCarAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            var createdCar = await _carRepository.AddAsync(car);
            var createdCarDto = _mapper.Map<CarDto>(createdCar);

            return new ApiResponse<CarDto>
            {
                Success = true,
                Payload = createdCarDto,
                Message = "Car added successfully."
            };
        }

        public async Task<ApiResponse<CarDto>> UpdateCarAsync(int id, CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            var updatedCar = await _carRepository.UpdateAsync(id, car);

            if (updatedCar == null)
            {
                return new ApiResponse<CarDto>
                {
                    Success = false,
                    Message = "Car not found.",
                    Errors = new List<string> { $"No car found with ID {id}." }
                };
            }

            var updatedCarDto = _mapper.Map<CarDto>(updatedCar);

            return new ApiResponse<CarDto>
            {
                Success = true,
                Payload = updatedCarDto,
                Message = "Car updated successfully."
            };
        }

        public async Task<ApiResponse<string>> DeleteCarAsync(int id)
        {
            var result = await _carRepository.DeleteAsync(id);

            if (!result)
            {
                return new ApiResponse<string>
                {
                    Success = false,
                    Message = "Car not found.",
                    Errors = new List<string> { $"No car found with ID {id}." }
                };
            }

            return new ApiResponse<string>
            {
                Success = true,
                Message = "Car deleted successfully."
            };
        }
    }
}
