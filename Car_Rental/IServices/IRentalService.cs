using Car_Rental.DTOS.Rental;
using Car_Rental.Entities;
using Car_Rental.Entities.Enums;

namespace Car_Rental.IServices
{
    public interface IRentalService
    {
        Task<int> GetTotalDays(DateTime startDate, DateTime endDate);
        Task<List<Rental>> GetAllPendingRentals();
        Task<List<Rental>> GetAllWaitingRentals();
        Task<List<Rental>> GetAllConfirmedRentals();
        Task<List<Rental>> GetAllRejectedRentals();
        Task<List<Rental>> GetAllRentalsForClient(string clientId);
        Task<List<Rental>> GetAllReqForCarById(int carId);
        Task<List<Rental>> GetAllReqPendAndRejForCarById(int carId);

        Task<Rental> PostRentCar(RentalDto rentalDto);

        Task<Rental> UpdateRental(int rentalId, RentalDto rentalDto);

        Task<bool> DeleteRental(int Id);
        Task<Rental> UpdateRentalStatus(int Id,decimal? totalCost, RentalStatus status);
        Task<Rental> GetRentalById(int rentalId);
    }
}
