using System.ComponentModel.DataAnnotations;

namespace Car_Rental.Entities
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public string FName {  get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        //For Owner
        public  ICollection<Car>? Cars { get; set; }
        // For Client
        public ICollection<Rental>? Rentals { get; set; }
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Admin = 0,
        User = 1
    }
}
