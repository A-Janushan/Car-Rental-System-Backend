using Car_Rental.Data;
using Car_Rental.Entities;
using Car_Rental.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CarRentalContext _dbContext;
        public AccountRepository(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> PostUser(ApplicationUser user)
        {
            var data = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            var data =  _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(c => c.Email == email);
        }
        public async Task<ApplicationUser> GetUserById(int userId)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(c => c.Id == userId);
        }
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            return  _dbContext.Users.Any(u => u.Email== email);
        }

        public async Task<bool> DeleteUser(ApplicationUser user)
        {
             _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
