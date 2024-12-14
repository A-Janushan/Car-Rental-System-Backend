using Car_Rental.DTOS.Account;
using Car_Rental.Entities;
using Car_Rental.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {        
                var data = await _accountService.PostUser(registerDto);      
                return Ok(data);          
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginDto loginDto)
        {
            try
            {
                var data = await _accountService.LogIn(loginDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            try
            {
                var data = await _accountService.UpdateUser(userDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var user = await _accountService.DeleteUser(userId);
                return Ok(user);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
