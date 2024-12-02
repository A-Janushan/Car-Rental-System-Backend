namespace CarRentalAPI.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string ModelName { get; set; } = string.Empty;
    }
}
