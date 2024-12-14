using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Rental
{
    public class RentalDto
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Pick_Location { get; set; }
        public string Ret_Location { get; set; }
        public string ClientId { get; set; }
        public int CarId { get; set; }
    }
}
