namespace CarRentalAPI.DTOs
{
    public class CarDto
    {
        public string RegistrationNo { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string EngineCapacity { get; set; } = string.Empty;
        public string EngineNumber { get; set; } = string.Empty;
        public string ChasyNumber { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public int YearOfManufacture { get; set; }
    }
}
