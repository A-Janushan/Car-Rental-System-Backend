using Car_Rental.Data;
using Car_Rental.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarRentalContext dbContext;

        public ReviewRepository(CarRentalContext _dbContext) 
        {
            dbContext = _dbContext;
        }
        public async Task<Review> GetReviewById(int Id)
        {
            return await dbContext.Reviews.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Review>> GetAllReviwsForCar(int carId)
        {
            return await dbContext.Reviews.Include(r => r.Rental).ThenInclude(re => re.User).Where(r => r.Rental.CarId == carId).ToListAsync();
        }

        public async Task<Review> PostReviewCar(Review review)
        {
            var data = await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Review> UpdateReviewCar(Review review)
        {
            dbContext.Reviews.Update(review);
            await dbContext.SaveChangesAsync();
            return review;
        }
        public async Task<bool> DeleteReviewCar(Review review)
        {
            dbContext.Reviews.Remove(review);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
