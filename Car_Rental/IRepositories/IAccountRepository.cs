using Car_Rental.Entities;

namespace Car_Rental.IRepositories
{
    public interface IAccountRepository 
    {
        Task<ApplicationUser> PostUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserById(int userId);
        Task<bool> DeleteUser(ApplicationUser user);
    }
}
