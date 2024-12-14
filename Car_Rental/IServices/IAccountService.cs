using Car_Rental.DTOS.Account;
using Car_Rental.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Car_Rental.IServices
{
    public interface IAccountService
    {
        Task<Token> PostUser(RegisterDto registerDto);
        Task<ApplicationUser> UpdateUser(UserDto userDto);
        Task<Token> LogIn(LoginDto logInDto);
        Task<bool> DeleteUser(int userId);
    }
}
