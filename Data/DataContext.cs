using CarRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, BrandName = "Toyota" },
                new Brand { Id = 2, BrandName = "Honda" },
                new Brand { Id = 3, BrandName = "Tesla" }
            );

            // Seed data for Models
            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, BrandId = 1, ModelName = "Corolla" },
                new Model { Id = 2, BrandId = 1, ModelName = "Camry" },
                new Model { Id = 3, BrandId = 2, ModelName = "Civic" },
                new Model { Id = 4, BrandId = 2, ModelName = "Accord" },
                new Model { Id = 5, BrandId = 3, ModelName = "Model S" },
                new Model { Id = 6, BrandId = 3, ModelName = "Model X" }
            );

            // Seed data for Cars
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    RegistrationNo = "ABC-1234",
                    BrandId = 1,
                    ModelId = 1,
                    EngineCapacity = "1800cc",
                    EngineNumber = "EN-TOY-001",
                    ChasyNumber = "CH-TOY-001",
                    FuelType = "Petrol",
                    YearOfManufacture = 2015
                },
                new Car
                {
                    Id = 2,
                    RegistrationNo = "XYZ-5678",
                    BrandId = 2,
                    ModelId = 3,
                    EngineCapacity = "1500cc",
                    EngineNumber = "EN-HON-002",
                    ChasyNumber = "CH-HON-002",
                    FuelType = "Diesel",
                    YearOfManufacture = 2018
                },
                new Car
                {
                    Id = 3,
                    RegistrationNo = "TES-9001",
                    BrandId = 3,
                    ModelId = 5,
                    EngineCapacity = "0cc", // Electric car
                    EngineNumber = "EN-TES-003",
                    ChasyNumber = "CH-TES-003",
                    FuelType = "Electric",
                    YearOfManufacture = 2020
                }
            );
        }
    }
}

