using Car_Rental.DTOS.Car;
using Car_Rental.DTOS.Rental;
using Car_Rental.Entities;
using Car_Rental.Entities.Enums;
using Car_Rental.IServices;
using Car_Rental.Repositories;

namespace Car_Rental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task<int> GetTotalDays(DateTime startDate, DateTime endDate)
        {
            var data = _rentalRepository.GetTotalDays(startDate, endDate);
            return data;  
        }
        public async Task<List<Rental>> GetAllPendingRentals()
        {
            var data = await _rentalRepository.GetAllPendingRentals();
            foreach (var item in data)
            {
                var days = item.End_Date.Subtract(item.Start_Date).Days;
                item.Total_Cost = item.Car.Cost_Per_Day * days;
            }
            return data;
        }

        public async Task<List<Rental>> GetAllWaitingRentals()
        {
            var data = await _rentalRepository.GetAllWaitingRentals();
          
            return data;
        }
        public async Task<List<Rental>> GetAllConfirmedRentals()
        {
            var data = await _rentalRepository.GetAllConfirmedRentals();    
            return data;
        }
        public async Task<List<Rental>> GetAllRejectedRentals()
        {
            var data = await _rentalRepository.GetAllRejectedRentals(); 
            return data;
        }
        public async Task<List<Rental>> GetAllRentalsForClient(string clientId)
        {
            var data = await _rentalRepository.GetAllRentalsForClient(clientId);
            return data;    
        }
        public async Task<List<Rental>> GetAllReqForCarById(int carId)
        {
            var data = await _rentalRepository.GetAllReqForCarById(carId);
            return data;
        }
        public async Task<List<Rental>> GetAllReqPendAndRejForCarById(int carId)
        {
            var data = await _rentalRepository.GetAllReqPendAndRejForCarById(carId);
            return data;
        }

        public async Task<Rental> PostRentCar(RentalDto rentalDto)
        {
            Rental rental = new Rental()
            {
                Start_Date = rentalDto.Start_Date,
                End_Date = rentalDto.End_Date,
                Pick_Location = rentalDto.Pick_Location,
                Ret_Location = rentalDto.Ret_Location,
                Status = RentalStatus.Pending,
                CarId = rentalDto.CarId,
                ClientId = rentalDto.ClientId,
            };


            var data = await _rentalRepository.PostRentCar(rental);

            return data;
        }

        public async Task<Rental> GetRentalById(int rentalId)
        {
            var data = await _rentalRepository.GetRentalById(rentalId);
            return data;
        }


        public async Task<Rental> UpdateRental(int rentalId, RentalDto rentalDto)
        {
            var getCar = await _rentalRepository.GetRentalById(rentalId);
            var data = await _rentalRepository.UpdateRental(getCar);
            return data;
        }
        public async Task<bool> DeleteRental(int rentalId)
        {
            var getCar = await _rentalRepository.GetRentalById(rentalId);
            var data = await _rentalRepository.DeleteRental(getCar);
            return data;
        }

        public async Task<Rental> UpdateRentalStatus(int Id , decimal? totalCost, RentalStatus status)
        {
            var getRental = await _rentalRepository.GetRentalById(Id);
            getRental.Status = status;
            if(totalCost != null && getRental.Total_Cost == 0)
            {   
                getRental.Total_Cost = (decimal)totalCost;
            }
            var updated = await _rentalRepository.UpdateRental(getRental);
            return updated;
        }

    }
}
