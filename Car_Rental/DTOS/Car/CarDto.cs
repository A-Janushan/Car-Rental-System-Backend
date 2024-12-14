﻿using Car_Rental.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Car_Rental.DTOS.Car
{
    public class CarDto
    {
        public string Brand { get; set; }
        public string Modell { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public IFormFile? CarImage { get; set; }
        public CarTransType Trans_Type { get; set; }
        public int Seats { get; set; }
        public int Cost_Per_Day { get; set; }
        public bool IsAvailable { get; set; }
        public string? OwnerId { get; set; }
    }
}
