using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign Key (User)
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int CarId { get; set; } // Foreign Key (Car)
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string Status { get; set; } // Pending, Approved, Rejected, Completed

        [Required]
        public decimal Price { get; set; }
        public DateTime? ApprovedAt { get; set; }
        // New columns (Nullable to avoid issues with existing data)
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
