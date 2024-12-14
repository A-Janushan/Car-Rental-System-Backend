using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Account
{
    public class ChangePasswordDTO
    {
     
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
