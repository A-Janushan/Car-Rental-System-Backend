using Car_Rental.DTOS.Rental;
using Car_Rental.Entities.Enums;
using Car_Rental.Entities;
using Car_Rental.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getAllPendingRentals")]
        public async Task<IActionResult> GetAllPendingRentals()
        {
            try
            {
                var data = await _rentalService.GetAllPendingRentals();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllWaitingRentals")]
        public async Task<IActionResult> GetAllWaitingRentals()
        {
            try
            {
                var data = await _rentalService.GetAllWaitingRentals();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllConfirmedRentals")]
        public async Task<IActionResult> GetAllConfirmedRentals()
        {
            try
            {
                var data = await _rentalService.GetAllConfirmedRentals();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getAllRejectedRentals")]
        public async Task<IActionResult> GetAllRejectedRentals()
        {
            try
            {
                var data = await _rentalService.GetAllRejectedRentals();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllRentalsByClientId(string id)
        {
            try
            {
                var data = await _rentalService.GetAllRentalsForClient(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            try
            {
                var data = await _rentalService.GetRentalById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getAllReqForCarById/{id}")]
        public async Task<IActionResult> GetAllReqForCarById(int id)
        {
            try
            {
                var data = await _rentalService.GetAllReqForCarById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(RentalDto rentalDto)
        {
            try
            {
                var data = await _rentalService.PostRentCar(rentalDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getTotalPrice")]
        public async Task<IActionResult> GetTotalPrice(int costPerDay, DateTime start, DateTime end)
        {
            try
            {
               // var data = await _rentalService.Get
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(int id, decimal? totalCost, RentalStatus status)
        {
            try
            {
                var data = await _rentalService.UpdateRentalStatus(id, totalCost, status);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("RejectRequest/{id}")]
        public async Task<IActionResult> RejectRequest(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("PaymentRequest/{id}")]
        public async Task<IActionResult> PaymentRequest(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ConfirmRequest/{id}")]
        public async Task<IActionResult> ConfirmRequest(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
 


}
