using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Account
{
    public class LoginDto
    {
      
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
