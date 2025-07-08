using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }  //  Hashed Password

        [Required]
        public string Role { get; set; } = "User";  //  Default Role
        public bool Report { get; set; } = false;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;  // ✅ Auto-set on creation
    }
}
