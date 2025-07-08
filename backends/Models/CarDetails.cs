using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class CarDetails
    {
        public int Id { get; set; }
        public int CarId { get; set; }  // Foreign Key
        [ForeignKey("CarId")]
        [JsonIgnore]
        public Car Car { get; set; }
        [Required]
        public string Category { get; set; }  // e.g., Hatchback, SUV, Sports
        [Required]
        public int Mileage { get; set; }  // e.g., 15 km/l
        [Required]
        public string Transmission { get; set; }  // Automatic, Manual
        [Required]
        public string FuelType { get; set; }  // Petrol, Diesel, Electric
        [Required]
        public int SeatingCapacity { get; set; }  // Number of seats
        public int? DiscountPercentage { get; set; }  // Optional
        
    }
}
