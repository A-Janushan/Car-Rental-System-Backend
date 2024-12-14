using Car_Rental.Entities;

namespace Car_Rental.IServices
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviwsForCar(int carId);
    }
}
