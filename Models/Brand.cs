namespace CarRentalAPI.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}
