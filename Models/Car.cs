namespace CarRentalAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string RegistrationNo { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;
        public string EngineCapacity { get; set; } = string.Empty;
        public string EngineNumber { get; set; } = string.Empty;
        public string ChasyNumber { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty; // Enum can be used
        public int YearOfManufacture { get; set; }
    }
}
