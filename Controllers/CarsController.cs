using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Services;
using CarRentalAPI.DTOs;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars() => Ok(await _carService.GetAllCarsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id) => Ok(await _carService.GetCarByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddCar(CarDto carDto) => Ok(await _carService.AddCarAsync(carDto));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, CarDto carDto) => Ok(await _carService.UpdateCarAsync(id, carDto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id) => Ok(await _carService.DeleteCarAsync(id));
    }
}
