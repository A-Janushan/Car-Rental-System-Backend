using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Review
{
    public class ReviewDto
    {
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public int RentalId { get; set; }
    }
}
