using Microsoft.EntityFrameworkCore;
using backend.Models;
using System;
using backend.Helpers;
using Microsoft.EntityFrameworkCore.Internal;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; } // Car table
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<CarReview> CarReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Modify passwords before storing them
            var modifiedAdminPassword = PasswordModifier.ModifyPassword("Arhamkalamadmin@123");
            var modifiedUserPassword = PasswordModifier.ModifyPassword("User@123");

            // Seed Users with modified passwords
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1000,
                    Username = "ArhamAdmin",
                    Email = "arhamkalam@admin.com",
                    PasswordHash = modifiedAdminPassword, //  Modified password (not plain text)
                    Role = "Admin",
                    Report = false,
                    DateCreated = DateTime.UtcNow
                },
                new User
                {
                    Id = 2000,
                    Username = "User",
                    Email = "user@gmail.com",
                    PasswordHash = modifiedUserPassword, //  Modified password (not plain text)
                    Role = "User",
                    Report = false,
                    DateCreated = DateTime.UtcNow
                }
            );

            //  Seed Cars
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2022,
                    Color = "White",
                    RentalPricePerDay = 5000,                    
                    Picture = "/pictures/Toyota-Corolla.jpg",
                    IsAvailable = true,
                    DateAdded = DateTime.UtcNow,
                    
                },
                new Car
                {
                    Id = 2,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2023,
                    Color = "Black",
                    RentalPricePerDay = 5500,
                    Picture = "/pictures/Honda-Civic.jpg",
                    IsAvailable = true,
                    DateAdded = DateTime.UtcNow,
                    
                },
                new Car
                {
                    Id = 3,
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2021,
                    Color = "Red",
                    RentalPricePerDay = 12000,
                    Picture = "/pictures/Ford-Mustang.jpg",
                    IsAvailable = true,
                    DateAdded = DateTime.UtcNow,
                    
                },
                new Car
                {
                    Id = 4,
                    Make = "Tesla",
                    Model = "Model 3",
                    Year = 2024,
                    Color = "Blue",
                    RentalPricePerDay = 7000,
                    Picture = "/pictures/Tesla-Model3.jpg",
                    IsAvailable = false,
                    DateAdded = DateTime.UtcNow,
                },
                new Car
                {
                    Id = 5,
                    Make = "BMW",
                    Model = "X5",
                    Year = 2022,
                    Color = "Grey",
                    RentalPricePerDay = 9000,
                    Picture = "/pictures/BMW-X5.jpg",
                    IsAvailable = true,
                    DateAdded = DateTime.UtcNow,
                    
                }
            );
            // Seed CarDetails
            modelBuilder.Entity<CarDetails>().HasData(
                new CarDetails
                {
                    Id = 1,
                    CarId = 1,  // Toyota Corolla
                    Category = "Sedan",
                    Mileage = 18,
                    Transmission = "Automatic",
                    FuelType = "Petrol",
                    SeatingCapacity = 5,
                    DiscountPercentage = 10
                },
                new CarDetails
                {
                    Id = 2,
                    CarId = 2,  // Honda Civic
                    Category = "Sedan",
                    Mileage = 17,
                    Transmission = "Manual",
                    FuelType = "Petrol",
                    SeatingCapacity = 5,
                    DiscountPercentage = 5
                },
                new CarDetails
                {
                    Id = 3,
                    CarId = 3,  // Ford Mustang
                    Category = "Sports",
                    Mileage = 12,
                    Transmission = "Automatic",
                    FuelType = "Petrol",
                    SeatingCapacity = 4,
                    DiscountPercentage = 15
                },
                new CarDetails
                {
                    Id = 4,
                    CarId = 4,  // Tesla Model 3
                    Category = "Electric",
                    Mileage = 400, // Range in km (electric cars)
                    Transmission = "Automatic",
                    FuelType = "Electric",
                    SeatingCapacity = 5,
                    DiscountPercentage = null
                },
                new CarDetails
                {
                    Id = 5,
                    CarId = 5,  // BMW X5
                    Category = "SUV",
                    Mileage = 15,
                    Transmission = "Automatic",
                    FuelType = "Diesel",
                    SeatingCapacity = 7,
                    DiscountPercentage = 8
                }
            );

        }
    }
}
