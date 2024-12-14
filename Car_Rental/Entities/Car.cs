namespace Car_Rental.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public int Cost_Per_Day { get; set; }
        public bool IsAvailable { get; set; }

        public string OwnerId { get; set; }
        public  ApplicationUser? User { get; set; }

        public  ICollection<Rental>? Rentals { get; set; }
    }
}
