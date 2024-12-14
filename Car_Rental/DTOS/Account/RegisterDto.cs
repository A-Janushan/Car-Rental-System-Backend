using Car_Rental.Entities;
using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Account
{
    public class RegisterDto
    {
        public IFormFile? ImageProfile { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public IFormFile? DrivingLic { get; set; }
        public IFormFile? NationalIdImage { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Roles Role { get; set; }
    }
}
