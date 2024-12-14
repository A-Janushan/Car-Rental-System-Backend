using Car_Rental.Entities;

namespace Car_Rental.Repositories
{
    public interface IRentalRepository
    {
        int GetTotalDays(DateTime startDate, DateTime endDate);
        Task<List<Rental>> GetAllPendingRentals();
        Task<List<Rental>> GetAllWaitingRentals();
        Task<List<Rental>> GetAllConfirmedRentals();
        Task<List<Rental>> GetAllRejectedRentals();
        Task<List<Rental>> GetAllRentalsForClient(string clientId);

        Task<List<Rental>> GetAllReqForCarById(int carId);

        Task<List<Rental>> GetAllReqPendAndRejForCarById(int carId);

        Task<Rental> PostRentCar(Rental rental);

        Task<Rental> UpdateRental(Rental rental);

        Task<bool> DeleteRental(Rental rental);

        Task<Rental> GetRentalById(int Id);
    }
}
