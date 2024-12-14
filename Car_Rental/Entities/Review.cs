using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int? RentalId { get; set; }
        public  Rental? Rental { get; set; }
    }
}
