using Car_Rental.DTOS.Car;
using Car_Rental.DTOS.Rental;
using Car_Rental.DTOS.Review;
using Car_Rental.Entities;
using Car_Rental.Entities.Enums;
using Car_Rental.IServices;
using Car_Rental.Repositories;

namespace Car_Rental.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<List<Review>> GetAllReviwsForCar(int carId)
        {
            var data = await _reviewRepository.GetAllReviwsForCar(carId);
            return data;
        }

        public async Task<Review> PostReviewCar(ReviewDto reviewDto)
        {
            Review review = new Review()
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                RentalId = reviewDto.RentalId,
            };

            var data = await _reviewRepository.PostReviewCar(review);
            return data;
        }

      

        public async Task<Review> GetReviewById(int reviewId)
        {
            var data = await _reviewRepository.GetReviewById(reviewId);
            return data;
        }

        public async Task<bool> DeleteReview(int reviewId)
        {
            var getCar = await _reviewRepository.GetReviewById(reviewId);
            var data = await _reviewRepository.DeleteReviewCar(getCar);
            return data;
        }
    }
}
