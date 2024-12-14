using Car_Rental.Entities;

namespace Car_Rental.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviwsForCar(int carId);

        Task<Review> PostReviewCar(Review review);

        Task<Review> UpdateReviewCar(Review review);

        Task<bool> DeleteReviewCar(Review review);
        Task<Review> GetReviewById(int reviewId);
    }
}
