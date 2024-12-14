using Car_Rental.DTOS.Car;
using Car_Rental.Entities;
using Car_Rental.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCarsByOwnerId(string id)
        {
            try
            {
                var data = await _carService.GetAllCarsForOwner(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var data = await _carService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getAllCarsExceptOwner/{id}")]
        public async Task<IActionResult> GetAllCarsExceptOwner(string id)
        {
            try
            {
                var data = await _carService.GetAllCarsExceptOnwerCar(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getDetailsCars/{id}")]
        public async Task<ActionResult<CarToReturnDto>> GetByIdAsync(int id)
        {
            try
            {
                var data = await _carService.GetCarById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CarDto model)
        {
            try
            {
                var data = await _carService.PostCar(model);
           
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CarDto model)
        {
            try
            {
                var data = await _carService.UpdateCar(id, model);  
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("cars-count")]
        public async Task<ActionResult<int>> CountOfBookings()
        {
            try
            {
                var data = await _carService.GetAll();         
                return Ok(data.Count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var data = await _carService.DeleteCar(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
