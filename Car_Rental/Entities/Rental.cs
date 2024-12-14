using Car_Rental.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Pick_Location { get; set; }
        public string Ret_Location { get; set; }
        public decimal Total_Cost { get; set; }
        public RentalStatus Status { get; set; }
        public string ClientId { get; set; }
        public  ApplicationUser? User { get; set; }
        public int CarId { get; set; }
        public  Car? Car { get; set; }

        public  ICollection<Review>? Reviews { get; set; }
    }
}
