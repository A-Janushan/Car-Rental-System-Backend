using Car_Rental.Data;
using Car_Rental.Entities.Enums;
using Car_Rental.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories
{
    public class RentalRepository :  IRentalRepository
    { private readonly CarRentalContext dbContext;
        public RentalRepository(CarRentalContext _dbContext) 
        {
            dbContext = _dbContext;
        }

        public int GetTotalDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan span = endDate - startDate;

            return span.Days + 1;
        }

        public async Task<List<Rental>> GetAllRentalsForClient(string clientId)
        {
            return await dbContext.Rentals.Include(r => r.Car).Where(c => c.ClientId == clientId).ToListAsync();
        }

        public async Task<List<Rental>> GetAllReqForCarById(int carId)
        {
            return await dbContext.Rentals.Include(r => r.User).Where(r => r.CarId == carId).ToListAsync();
        }

        public async Task<List<Rental>> GetAllReqPendAndRejForCarById(int carId)
        {
            return await dbContext.Rentals.Where(r => r.CarId == carId && r.Status == RentalStatus.Pending || r.Status == RentalStatus.Rejected).ToListAsync();
        }

        public async Task<List<Rental>> GetAllPendingRentals()
        {
            return await dbContext.Rentals.Include(r => r.User).Include(r => r.Car).ThenInclude(c => c.User).Where(r => r.Status == RentalStatus.Pending).ToListAsync();
        }

        public async Task<List<Rental>> GetAllWaitingRentals()
        {
            return await dbContext.Rentals.Include(r => r.User).Include(r => r.Car).ThenInclude(c => c.User).Where(r => r.Status == RentalStatus.WaitingForPayment).ToListAsync();
        }

        public async Task<List<Rental>> GetAllConfirmedRentals()
        {
            return await dbContext.Rentals.Include(r => r.User).Include(r => r.Car).ThenInclude(c => c.User).Where(r => r.Status == RentalStatus.Confirmed).ToListAsync();
        }

        public async Task<List<Rental>> GetAllRejectedRentals()
        {
            return await dbContext.Rentals.Include(r => r.User).Include(r => r.Car).ThenInclude(c => c.User).Where(r => r.Status == RentalStatus.Rejected).ToListAsync();
        }

        public async Task<Rental> PostRentCar(Rental rental)
        {
            var data = await dbContext.Rentals.AddAsync(rental);
            await dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Rental> UpdateRental(Rental rental)
        {
            dbContext.Rentals.Update(rental);
            await dbContext.SaveChangesAsync();
            return rental;
        }
        public async Task<bool> DeleteRental(Rental rental)
        {
            dbContext.Rentals.Remove(rental);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Rental> GetRentalById(int Id)
        {
            return await dbContext.Rentals.FirstOrDefaultAsync(c => c.Id == Id);
        }

        //public async Task<Rental> GetRentalById(int Id)
        //{
        //   var data = await dbContext.Rentals.Where(r => r.Id == Id).SingleOrDefaultAsync();
        //    return data;
        //}

    }
}
