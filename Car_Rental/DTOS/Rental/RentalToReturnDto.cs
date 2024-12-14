﻿using Car_Rental.Entities.Enums;

namespace Car_Rental.DTOS.Rental
{
    public class RentalToReturnDto
    {
        public int Id { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public decimal Total_Cost { get; set; }
        public string Pick_Location { get; set; }
        public string Ret_Location { get; set; }
        public RentalStatus Status { get; set; }
        public string CarImageURL { get; set; }
    }
}