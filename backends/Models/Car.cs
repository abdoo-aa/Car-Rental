using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; } // e.g., Toyota, Ford, Maruti Suzuki

        [Required]
        public string Model { get; set; } // e.g., Corolla, Mustang, Swift

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public decimal RentalPricePerDay { get; set; } // Price per day
        

        [Required]
        public string Picture { get; set; } // URL or Base64 Image String

        public bool IsAvailable { get; set; } = true; // Default to available

        public DateTime DateAdded { get; set; } = DateTime.UtcNow; // Automatically set date

        public CarDetails? CarDetails { get; set; }

    }
}
