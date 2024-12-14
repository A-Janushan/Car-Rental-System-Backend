namespace Car_Rental.DTOS.Account
{
    public class UserToReturnDto
    {
        public string Id { get; set; }
        public string ProfileURl { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string DrivingLicURl { get; set; }
        public string NationalIdURl { get; set; }
    }
}
