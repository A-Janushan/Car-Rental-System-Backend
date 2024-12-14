using Car_Rental.Entities.Enums;

namespace Car_Rental.DTOS.Car
{
    public class CarToReturnDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string CarImageURL { get; set; }
        public CarTransType Trans_Type { get; set; }
        public int Seats { get; set; }
        public int Cost_Per_Day { get; set; }
        public bool IsAvailable { get; set; }
        public string CarLocation { get; set; }

        public string OwnerId { get; set; }
    }
}
